using Domain.Ads.Handlers;
using Domain.Shared.Contracts.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Supervaga.Domain.Ads;

namespace Supervaga.Infra.DI
{
    public static class DiAd
    {
        public static IServiceCollection Add(
            IServiceCollection services
        )
        {
            services.AddTransient<IRepository<Ad>, AdRepository>();
            services.AddTransient<CreateAdHandler, CreateAdHandler>();
            services.AddTransient<UpdateAdHandler, UpdateAdHandler>();
            services.AddTransient<DeleteAdHandler, DeleteAdHandler>();

            return services;
        }
    }
}