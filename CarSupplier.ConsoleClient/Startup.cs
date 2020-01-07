using CarSupplier.Application.MessageConsumers.CarManufacturer;
using CarSupplier.Application.Messages.CarManufacturer;
using CarSupplier.DA.EFCore.Extensions;
using CarSupplier.Hosting;
using CarSupplier.MessageBroker.CarManufacturer;
using Inspire.MessageBroker;
using Inspire.MessageBroker.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarSupplier.ConsoleClient
{
    public class Startup : BaseStatupWithConfigure
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureSpecificServices(IServiceCollection services)
        {
            services.UseSql(this.Configuration);

            CarSupplier.Configuration.Configuration.Configure(services);

            services.AddScoped<IMessageBroker, RabbitMQMessageBroker>();

            services.AddScoped<ICarManufacturerMessageConsumer<HondaCarSpecificationMessage>, HondaCarManufacturerConsumer>();
            services.AddScoped<ICarManufacturerMessageConsumer<FordCarSpecificationMessage>, FordCarManufacturerConsumer>();
        }

        public override void Configure()
        {
            this.ServiceProvider.CreateDbIfNotExist();
        }
    }
}
