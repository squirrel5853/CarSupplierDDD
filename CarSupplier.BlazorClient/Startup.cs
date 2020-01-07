using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSupplier.Application.MessageConsumers.CarManufacturer;
using CarSupplier.Application.Messages.CarManufacturer;
using CarSupplier.BlazorClient.Data;
using CarSupplier.DA.EFCore.Extensions;
using CarSupplier.Hosting;
using CarSupplier.MessageBroker.CarManufacturer;
using Inspire.MessageBroker;
using Inspire.MessageBroker.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarSupplier.BlazorClient
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.ServiceProvider.CreateDbIfNotExist();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        public override void ConfigureSpecificServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<CounterService>();


            services.UseSql(this.Configuration);

            CarSupplier.Configuration.Configuration.Configure(services);

            services.AddSingleton<IMessageBroker, RabbitMQMessageBroker>();

            services.AddScoped<ICarManufacturerMessageConsumer<HondaCarSpecificationMessage>, HondaCarManufacturerConsumer>();
            services.AddScoped<ICarManufacturerMessageConsumer<FordCarSpecificationMessage>, FordCarManufacturerConsumer>();
        }
    }
}
