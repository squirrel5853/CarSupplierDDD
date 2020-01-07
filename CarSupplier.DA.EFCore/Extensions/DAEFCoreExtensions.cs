using CarSupplier.DA.EFCore.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarSupplier.DA.EFCore.Extensions
{
    public static class DAEFCoreExtensions
    {
        public static void UseSql(this IServiceCollection services, IConfiguration configuration)
        {
            SqlConfiguration.Configure<CarSupplierContext>(services, configuration);
        }

        public static void CreateDbIfNotExist(this IServiceProvider serviceProvider)
        {
            SqlConfiguration.CreateDatabase<CarSupplierContext>(serviceProvider);
        }
    }
}
