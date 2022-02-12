using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Hosting;
using Supervaga.Domain.DocumentCommands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using http = Microsoft.AspNetCore.Http;

namespace Supervaga.Domain.Documents.Hanlders
{
    public class UploadHandler : IHandler<DocumentCommand>
    {
        public UploadHandler(
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


        public async Task<IResult> Handle(DocumentCommand command, object? data = null)
        {

            command.Validate();

            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            IList<http.IFormFile> files = command.docs!;

            long size = files.Sum(f => f.Length);

            var rootPath = Path.Combine(_env.ContentRootPath, "Resources", "Documents");

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            Document document = new Document();
            
            foreach (var file in files)
            {
                var filePath = Path.Combine(rootPath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    document = new Document
                    {
                        FileName = file.FileName,
                        FileSize = file.Length,
                        FileUrl = filePath,
                        ContentType = file.ContentType
                    };

                    await file.CopyToAsync(stream);

                    await _repository.Create(document);
                }
            }

            return new OkResult<Document>(true, 1, document);

        }
    }
}