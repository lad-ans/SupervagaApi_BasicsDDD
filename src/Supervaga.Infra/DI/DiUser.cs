using Domain.Shared.Contracts.Repositories;
using Domain.Users.Handlers;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Supervaga.Domain.Users;

namespace Supervaga.Infra.DI
{
    public static class DiUser
    {
        public static IServiceCollection Add(
            IServiceCollection services
        )
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<CreateUserHandler, CreateUserHandler>();
            services.AddTransient<UpdateUserHandler, UpdateUserHandler>();
            services.AddTransient<DeleteUserHandler, DeleteUserHandler>();

            return services;
        }
    }
}