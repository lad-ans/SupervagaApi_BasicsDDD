using System.Security.Claims;
using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Auth.Commands;
using Supervaga.Domain.Auth.Entities;
using Supervaga.Domain.Auth.Helpers;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;

namespace Supervaga.Domain.Auth.Handlers
{
    public class SocialAuthHandler : IHandler<SocialAuthCommand>
    {
        public SocialAuthHandler(
            IRepository<User> userRepository,
            NotificationContext notificationContext
        )
        {
            _userRepository = userRepository;
            _notificationContext = notificationContext;
        }
        private readonly IRepository<User> _userRepository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(SocialAuthCommand command, object? data)
        {
            await Task.FromResult(0);

            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var claimsPrincipal = (ClaimsPrincipal)data!;
            var usrResult = ClaimsHelper.UserGenerator(claimsPrincipal);

            if (usrResult is ValidationErrorsResult)
            {
                _notificationContext.AddNotification(
                    "UserNotFound", 
                    "Usuário não encontrado"
                );
                return new ValidationErrorsResult();
            }

            var usr = ((OkResult<User>)usrResult).Data!;

            await _userRepository.Create(usr);
            var token = TokenHelper.GenerateToke(usr);
            var loginResult = new Login { User = usr, Token = token };

            return new OkResult<Login>(true, 1, loginResult);
        }
    }
}

