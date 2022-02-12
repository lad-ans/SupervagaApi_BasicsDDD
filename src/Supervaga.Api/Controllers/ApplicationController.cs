using Domain.Applications.Handlers;
using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Applications.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;

namespace Supervaga.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("v1/applications")]
    public class ApplicationController : ControllerBase
    {

        /// <summary>
        /// </summary>
        public ApplicationController(
            IRepository<Application> repository,
            IRepository<Ad> adRepository
        )
        {
            this.repository = repository;
            this.adRepository = adRepository;
        }
        private readonly IRepository<Application> repository;
        private readonly IRepository<Ad> adRepository;

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Application>>> Get(
            [FromQuery] int page = 0,
            [FromQuery] int limit = 25
        )
        {
            var result = await repository.Get(page, limit);
            return Ok(new OkResult<List<Application>>(true, result.Count, result));
        }

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("search/{key}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Application>>> Search(
            string key,
            [FromQuery] int page = 0,
            [FromQuery] int limit = 25
        )
        {
            var result = await repository.Search(key, page, limit);
            return Ok(new OkResult<List<Application>>(true, result.Count, result));
        }

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<Application>> Get(Guid id)
        {
            var app = await repository.Get(id);
            if (app.Ad == null)
                return NotFound(new ErrorResult(false, "Candidatura não encontrada"));
            return Ok(new OkResult<Application>(true, 1, app));
        }

        /// <summary>
        /// </summary>
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<Application>> Put(
            [FromServices] UpdateApplicationHandler handler,
            [FromBody] UpdateApplicationCommand command,
            [FromRoute] Guid id
        )
        {
            var result = await handler.Handle(command, id) as OkResult<Application>;
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(
        )
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }
    }
}