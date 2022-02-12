using Domain.Applications.Handlers;
using Domain.Shared.Contracts.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Supervaga.Domain.Applications;

namespace Supervaga.Infra.DI
{
    public static class DiApplication
    {
        public static IServiceCollection Add(
            IServiceCollection services
        )
        {
            services.AddTransient<IRepository<Candidate>, CandidateRepository>();
            services.AddTransient<IRepository<Application>, ApplicationRepository>();
            services.AddTransient<UpdateApplicationHandler, UpdateApplicationHandler>();

            return services;
        }
    }
}