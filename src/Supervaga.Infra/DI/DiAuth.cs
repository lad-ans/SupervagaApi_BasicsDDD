using Domain.Shared.Contracts.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Supervaga.Domain.Auth.Handlers;
using Supervaga.Domain.Users;

namespace Supervaga.Infra.DI
{
    public static class DiAuth

    {
        public static IServiceCollection Add(
            IServiceCollection services
        )
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<LoginHandler, LoginHandler>();
            services.AddTransient<SocialAuthHandler, SocialAuthHandler>();

            return services;
        }
    }
}