using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Supervaga.Domain.DocumentCommands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;

namespace Supervaga.Domain.Documents.Handlers
{
    public class DownloadHandler : IHandler<DocumentCommand>
    {
        public DownloadHandler(
            NotificationContext notificationContext,
            IWebHostEnvironment env,
            IRepository<Document> repository
        )
        {
            _notificationContext = notificationContext;
            _env = env;
            _repository = repository;
        }

        private readonly NotificationContext _notificationContext;
        private readonly IWebHostEnvironment _env;
        private readonly IRepository<Document> _repository;


        public async Task<IResult> Handle(DocumentCommand command, object? objectId)
        {
            var id = (Guid)objectId!;

            var provider = new FileExtensionContentTypeProvider();

            var document = await _repository.Get(id);
            if (document == null)
            {
                _notificationContext.AddNotification("NotFound", "Not Found");
                return new ValidationErrorsResult();
            }

            var file = Path.Combine(_env.ContentRootPath, "Resources", "Documents", document.FileName!);

            string? contentType;
            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }
            else
            {
                contentType = document.ContentType;
            }

            byte[] fileBytes;
            if (System.IO.File.Exists(file))
                fileBytes = System.IO.File.ReadAllBytes(file);
            else
            {
                _notificationContext.AddNotification("NotFound", "Not Found");
                return new ValidationErrorsResult();
            }

            var data = new DownloadedData
            {
                FileBytes = fileBytes,
                ContentType = contentType,
                FileName = document.FileName,
            };

            return new OkResult<DownloadedData>(true, 1, data);

        }
    }

    public class DownloadedData
    {
        public string? FileName { get; set; }
        public byte[]? FileBytes { get; set; }
        public string? ContentType { get; set; }
    }

}