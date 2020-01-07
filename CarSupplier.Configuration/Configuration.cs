using CarSupplier.DA;
using CarSupplier.DA.Entities;
using CarSupplier.DA.Repositories;
using CarSupplier.Domain.Models;
using CarSupplier.Domain.Interfaces;
using CarSupplier.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarSupplier.DA.Interfaces;
using CarSupplier.Hosting;
using CarSupplier.Application;

namespace CarSupplier.Configuration
{
    public class Configuration
    {
        public static void Configure(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IRepository<TyreEntity, TyreFilter, int>, TyreRepository>();
            services.AddScoped<IRepository<WheelEntity, WheelFilter, int>, WheelRepository>();
            services.AddScoped<IRepository<CarEngineEntity, EngineFilter, Guid>, CarEngineRepository>();
            services.AddScoped<IRepository<CarPaintEntity, PaintFilter, int>, PaintRepository>();

            //Providers
            services.AddScoped<IProvider<TyreEntity, TyreFilter>, TyreProvider>();
            services.AddScoped<IProvider<WheelEntity, WheelFilter>, WheelProvider>();
            services.AddScoped<IProvider<CarEngineEntity, EngineFilter>, CarEngineProvider>();
            services.AddScoped<IProvider<CarPaintEntity, PaintFilter>, CarPaintProvider>();
            //Builders
            services.AddScoped<IVehicleBuilder<FordCar>, FordCarBuilder>();

            //Services
            services.AddScoped<ICarService<FordCar>, FordCarService>();

            services.AddSingleton<IApplicationRunner, ApplicationRunner>();
        }
    }
}
