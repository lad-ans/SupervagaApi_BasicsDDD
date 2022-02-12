using Domain.Shared.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Supervaga.Domain.Auth.Commands;
using Supervaga.Domain.Auth.Entities;
using Supervaga.Domain.Auth.Handlers;
using Supervaga.Domain.Results;
using Supervaga.Domain.Users;

namespace Supervaga.Api.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("v1/login")]
    public class AuthController : ControllerBase
    {

        /// <summary>
        /// </summary>
        public AuthController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Login>> Login(
            [FromServices] LoginHandler handler,
            [FromBody] LoginCommand command
        )
        {
            var result = await handler.Handle(command) as OkResult<Login>;
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        [HttpPost]
        [Route("google")]
        public async Task<ActionResult<Login>> GoogleLogin(
            [FromServices] SocialAuthHandler handler,
            [FromQuery] SocialAuthCommand command
        )
        {
            var result = await handler.Handle(command, User) as OkResult<Login>;
            return Ok(result);
        }
    }
}

