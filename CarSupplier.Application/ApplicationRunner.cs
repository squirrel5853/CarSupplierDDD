using CarSupplier.Application.Messages.CarManufacturer;
using CarSupplier.Hosting;
using CarSupplier.MessageBroker.CarManufacturer;
using Inspire.MessageBroker.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarSupplier.Application
{
    public class ApplicationRunner : IApplicationRunner
    {
        public IServiceProvider ServiceProvider { get; }
        public IMessageBroker MessageBroker { get; }

        public ApplicationRunner(IServiceProvider serviceProvider, IMessageBroker messageBroker)
        {
            this.ServiceProvider = serviceProvider;
            this.MessageBroker = messageBroker;

            messageBroker.Subscribe(this.ServiceProvider.GetService<ICarManufacturerMessageConsumer<HondaCarSpecificationMessage>>());
            messageBroker.Subscribe(this.ServiceProvider.GetService<ICarManufacturerMessageConsumer<FordCarSpecificationMessage>>());
        }
        private void Initialise()
        {
            Task.Factory.StartNew(() => {
                this.MessageBroker.Listen();
            });
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            Initialise();

            while (cancellationToken.IsCancellationRequested == false)
            {
                Console.WriteLine("hello");
                await Task.Delay(1000);
            }
        }

        public void Run()
        {
            Initialise();

            while (true)
            {
                Console.WriteLine("hello");
                Thread.Sleep(1000);
            }
        }
    }
}
