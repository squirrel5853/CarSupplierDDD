using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarSupplier.DA.EFCore.Sql
{
    public static class SqlConfiguration
    {
        public static void Configure<T>(IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddDbContext<T>(options =>
                options.UseSqlServer(configuration.GetConnectionString(typeof(T).Name)));
        }

        public static void CreateDatabase<T>(IServiceProvider serviceProvider) where T : DbContext
        {
            //using (var scope = serviceProvider.CreateScope())
            //{
            var services = serviceProvider;

            try
            {
                var context = services.GetRequiredService<T>();
                //context.Database.Migrate();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
        }
    }
}
