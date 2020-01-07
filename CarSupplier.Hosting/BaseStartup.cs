using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarSupplier.Hosting
{
    public abstract class BaseStartup
    {
        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            ConfigureSpecificServices(services);

            this.ServiceProvider = services.BuildServiceProvider();
        }

        public abstract void ConfigureSpecificServices(IServiceCollection services);
    }

    public abstract class BaseStatupWithConfigure : BaseStartup
    {
        public BaseStatupWithConfigure(IConfiguration configuration) : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            Configure();
        }

        public abstract void Configure();
    }
}
