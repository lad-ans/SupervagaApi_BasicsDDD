using Domain.Ads.Handlers;
using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Ads.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Users;

namespace Supervaga.Controllers
{
    /// <summary>
    /// AdController
    /// </summary>
    [ApiController]
    [Route("v1/ads")]
    public class AdController : ControllerBase
    {
        /// <summary>
        /// </summary>
        public AdController(
            IRepository<Ad> repository,
            IRepository<User> userRepository
        )
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }
        private readonly IRepository<Ad> repository;
        private readonly IRepository<User> userRepository;

        /// <summary>Get all Ads from Database</summary>
        /// <remarks>
        /// Sample request
        /// GET /v1/ads
        /// </remarks>
        /// <returns>Saved Ads list</returns>
        /// <response code="200">Saved Ads list</response>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Ad>>> Get(
            [FromQuery] int page = 0,
            [FromQuery] int limit = 25
        )
        {
            var result = await repository.Get(page, limit);
            return Ok(new OkResult<List<Ad>>(true, result.Count, result));
        }

        /// <summary>
        /// Get all matched Ads from Database
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <param name="page">Current page</param>
        /// <param name="limit">Ads limit</param>
        /// <remarks>
        /// Sample request
        /// GET /v1/ads/search/{keyword}
        /// </remarks>
        /// <returns>Saved Ads list</returns>
        /// <response code="200">Saved Ads list</response>
        /// <response code="400">No Ad matching the keyword</response>
        [HttpGet]
        [Route("search/{keyword}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Ad>>> Search(
            string keyword,
            [FromQuery] int page = 0,
            [FromQuery] int limit = 25
        )
        {
            var result = await repository.Search(keyword, page, limit);
            return Ok(new OkResult<List<Ad>>(true, result.Count, result));
        }

        /// <summary>
        /// Get matching Ad ID from Database
        /// </summary>
        /// <remarks>
        /// Sample request
        /// GET /v1/ads/{id}
        /// </remarks>
        /// <returns>Ad matching the ID</returns>
        /// <response code="200">Saved Ads matching the ID</response>
        /// <response code="400">No Ad matchs the ID</response>
        [HttpGet]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<Ad>> Get(Guid id)
        {
            var result = await repository.Get(id);
            if (result == null)
                return NotFound(new ErrorResult(false, "Vaga não encontrada"));
            return Ok(new OkResult<Ad>(true, 1, result));
        }

        /// <summary>
        /// Save received Ad on Database
        /// </summary>
        /// <param name="command">Ad to be saved on database</param>
        /// <param name="handler">Handler for Ad creation</param>
        /// <remarks>
        /// Sample request
        /// POST /v1/ads/
        /// {
        ///     "userId": "09df2cb0-2622-4ae2-9b13-f6fb6986d09a",
	    ///     "title": "any title",
        ///     "category": "any category",
        ///     "description": "any description of 15 characters",
        ///     "address": "any address",
        ///     "audienceGender": "string",
        ///     "createdAt": "2022-01-28T00:35:04.635Z",
        ///     "expiresAt": "2022-02-28T00:24:51.590Z",
        ///     "requirements": [
        ///         {
        ///             "adId": "6c7b601d-3e7f-4155-ba16-e4ed7f1d5ed0",
        ///             "Title": "requirement 1"
        ///         },
        ///         {
        ///             "adId": "6c7b601d-3e7f-4155-ba16-e4ed7f1d5ed0",
        ///             "Title": "requirement 2"
        ///         }
        ///     ],
        ///     "advantages": [
        ///         {
        ///             "adId": "6c7b601d-3e7f-4155-ba16-e4ed7f1d5ed0",
        ///             "title": "advantage 1"
        ///         },
        ///         {
        ///             "adId": "6c7b601d-3e7f-4155-ba16-e4ed7f1d5ed0",
        ///             "title": "advantage 2"
        ///         },
        ///         {
        ///             "adId": "6c7b601d-3e7f-4155-ba16-e4ed7f1d5ed0",
        ///             "title": "advantage 3"
        ///         }
        ///     ],
        ///     "salaryOffer": 400
        /// }
        /// </remarks>
        /// <returns>Saved Ad</returns>
        /// <response code="200">Success saving Ad</response>
        /// <response code="400">Error validating data</response>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Ad>> Post(
            [FromServices] CreateAdHandler handler,
            [FromBody] CreateAdCommand command
        )
        {
            var result = await handler.Handle(command) as OkResult<Ad>;
            return Ok(result);
        }

        /// <summary>
        /// Update received Ad on database
        /// </summary>
        /// <param name="id">Ad ID to be updated</param>
        /// <param name="command">Ad to be updated</param>
        /// <param name="handler">Handler for the update</param>
        /// <remarks>
        /// Sample request
        /// PUT /v1/ads/{id}
        /// {
	    ///     "title": "any title updated",
        /// }
        /// </remarks>
        /// <returns>Updated Ad</returns>
        /// <response code="200">Success updating Ad</response>
        /// <response code="400">Error validating data</response>
        /// <response code="400">No match for the ID</response>
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<Ad>> Put(
            [FromServices] UpdateAdHandler handler,
            [FromBody] UpdateAdCommand command,
            [FromRoute] Guid id
        )
        {
            var result = await handler.Handle(command, id) as OkResult<Ad>;
            return Ok(result);
        }

        /// <summary>
        /// Remove Ad by ID from Database
        /// </summary>
        /// <param name="id">Ad ID to be removed</param>
        /// <param name="handler">Handler for remove Ad</param>
        /// <remarks>
        /// Sample request
        /// DELETE /v1/ads/{id}
        /// </remarks>
        /// <returns>Removed Ad ID</returns>
        /// <response code="200">Success removing Ad</response>
        /// <response code="400">Error validating data</response>
        /// <response code="400">No matchs for the ID</response>
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(
            [FromServices] DeleteAdHandler handler,
            Guid id
        )
        {
            var result = await handler.Handle(new DeleteAdCommand(id), id) as OkResult<string>;
            return Ok(result);
        }
    }
}