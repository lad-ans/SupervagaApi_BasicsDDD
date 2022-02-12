using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Supervaga.Infra.Data.DataContexts;

namespace Supervaga.Infra.DI
{
    public static class DiDataContext
    {
        public static IServiceCollection Call(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            // summary:
            //     DataContext Setup

            // services.AddDbContext<DataContext>(
            //     options => options.UseInMemoryDatabase("supervaga_db")
            // );

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(DataContext).Assembly.FullName)
                ),

                //  summary:
                //      Creates a new instance of service to each call
                //  remarks:
                //      Avoid concurrencies exceptions working on threads
                
                ServiceLifetime.Transient
            );

            return services;
        }
    }
}