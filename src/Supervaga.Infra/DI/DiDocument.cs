using Domain.Shared.Contracts.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Supervaga.Domain.Documents;
using Supervaga.Domain.Documents.Handlers;
using Supervaga.Domain.Documents.Hanlders;

namespace Supervaga.Infra.DI
{
    public static class DiDocument
    {
        public static IServiceCollection Add(
            IServiceCollection services
        )
        {
            services.AddTransient<IRepository<Document>, DocumentRepository>();
            services.AddTransient<UploadHandler, UploadHandler>();
            services.AddTransient<DownloadHandler, DownloadHandler>();

            return services;
        }
    }
}