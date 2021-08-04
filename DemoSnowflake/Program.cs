using DemoSnowflake.Infra.Data;
using DemoSnowflake.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DemoSnowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var productRepository = serviceProvider.GetService<IProductRepository>();
            var listProduct = productRepository.Get();
            //Apply linq as you wish
            //Ex: var result = listProduct.Where(a => a.Name == "Andre");
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, IProductRepository>()
                .AddScoped<ISessionDataContext, SessionDataContext>()
                .AddScoped<IConnectionFactory, DefaultSqlConnectionFactory>();
        }
    }
}
