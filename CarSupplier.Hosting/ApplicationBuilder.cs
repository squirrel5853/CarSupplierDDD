using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CarSupplier.Hosting
{
    public class ApplicationBuilder<R> : IHost where R : IApplicationRunner
    {
        private ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();

        private BaseStartup startup;

        public IServiceProvider Services => startup.ServiceProvider;

        private ApplicationBuilder(BaseStartup startup)
        {
            this.startup = startup;
        }

        delegate T ObjectActivator<T>(params object[] args);

        static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp = new Expression[paramsInfo.Length];

            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            NewExpression newExp = Expression.New(ctor, argsExp);

            LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }

        public static ApplicationBuilder<R> UseStartup<T>(params string[] args) where T : BaseStartup
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true)
               .AddEnvironmentVariables(prefix: "PREFIX_")
               .AddCommandLine(args);

            ConstructorInfo ctor = typeof(T).GetConstructors().First();
            ObjectActivator<T> createdActivator = GetActivator<T>(ctor);

            //create an instance:
            BaseStartup startup = createdActivator(configurationBuilder.Build());

            return new ApplicationBuilder<R>(startup);
        }

        public ApplicationBuilder<R> Build()
        {
            var serviceCollection = new ServiceCollection();
            this.startup.ConfigureServices(serviceCollection);
            this.startup.Configure(startup.ServiceProvider);
            return this;
        }

        public void Run()
        {
            R runner = this.startup.ServiceProvider.GetService<R>();

            tasks.Add(Task.Factory.StartNew(() => runner.Run(), TaskCreationOptions.LongRunning));
            Task task2 = Task.Factory.StartNew(() =>
            {
               Console.Read();
            }, TaskCreationOptions.LongRunning);

            tasks.Add(task2);

            Task.WaitAll(task2);
        }

        public void RunAsync(CancellationToken cancellationToken = default)
        {
            R runner = this.startup.ServiceProvider.GetService<R>();

            tasks.Add(Task.Factory.StartNew(async () => await runner.RunAsync(cancellationToken), cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default));
            Task task2 = Task.Factory.StartNew(() =>
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    try
                    {
                        ConsoleReader.Read(cancellationToken, 10000);

                        break;
                    }
                    catch (TimeoutException)
                    {

                    }
                }
            }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            tasks.Add(task2);

            Task.WaitAll(task2);
        }


        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            this.RunAsync();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            this.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Task.WaitAll(tasks.ToArray(), 5000);

            foreach (Task task in tasks)
            {
                task.Dispose();
            }
        }
    }
}
