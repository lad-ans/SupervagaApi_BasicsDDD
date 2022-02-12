using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supervaga.Domain.DocumentCommands;
using Supervaga.Domain.Documents;
using Supervaga.Domain.Documents.Handlers;
using Supervaga.Domain.Documents.Hanlders;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;

namespace Supervaga.Api.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("v1/documents")]
    public class DocumentController : ControllerBase
    {

        /// <summary>
        /// </summary>
        public DocumentController(IRepository<Document> docRepository)
        {
            _docRepository = docRepository;
        }

        private readonly IRepository<Document> _docRepository;

        /// <summary>
        /// </summary>
        [HttpPost]
        [Route("upload")]
        [Authorize]
        public async Task<ActionResult<Document>> Upload(
            [FromServices] UploadHandler handler,
            [FromForm] List<IFormFile> documents
        )
        {

            var result = await handler.Handle(new DocumentCommand(documents)) as OkResult<Document>;
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("download/{id:Guid}")]
        [Authorize]
        public async Task<ActionResult> Download(
            Guid id,
            [FromServices] DownloadHandler handler
        )
        {
            var result = await handler.Handle(new DocumentCommand(), id);
            var file = result as OkResult<DownloadedData>;
            if (result is ValidationErrorsResult)
                return Ok(result);
            else
                return File(file!.Data!.FileBytes!, file.Data.ContentType!, file.Data.FileName);
        }
    }
}

