using Domain.Shared.Contracts.Repositories;
using Domain.Users.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supervaga.Domain.Auth.Entities;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Users;
using Supervaga.Domain.Users.Commands;

namespace Supervaga.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("v1/Users")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// </summary>
        public UserController(IRepository<User> repository)
        {
            this.repository = repository;
        }
        private readonly IRepository<User> repository;

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<User>>> Get(
            [FromQuery] int page = 0,
            [FromQuery] int limit = 25
        )
        {
            var result = await repository.Get(page, limit);
            return Ok(new OkResult<List<User>>(true, result.Count, result));
        }

        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Get(
            Guid id
        )
        {
            var result = await repository.Get(id);
            if (result == null)
                return NotFound(new ErrorResult(false, "Usuário não encontrado"));
            return Ok(new OkResult<User>(true, 1, result));
        }

        /// <summary>
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Login>> Post(
            [FromServices] CreateUserHandler handler,
            [FromBody] CreateUserCommand command
        )
        {
            var result = await handler.Handle(command);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<User>> Put(
            [FromServices] UpdateUserHandler handler,
            [FromBody] UpdateUserCommand command,
            Guid id
        )
        {
            var result = await handler.Handle(command, id) as OkResult<User>;
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(
            [FromServices] DeleteUserHandler handler,
            Guid id
        )
        {
            var result = await handler.Handle(new DeleteUserCommand(id), id) as OkResult<string>;
            return Ok(result);
        }
    }
}