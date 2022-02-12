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
    public class LoginHandler : IHandler<LoginCommand>
    {
        public LoginHandler(IRepository<User> userRepository, NotificationContext notificationContext)
        {
            _userRepository = userRepository;
            _notificationContext = notificationContext;
        }
        private readonly IRepository<User> _userRepository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(LoginCommand command, object? data = null)
        {
            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var usr = await _userRepository.Get(command.Email!, command.Password!);

            if (usr == null)
            {
                _notificationContext.AddNotification("UserNotFound", "Email ou Senha Inválidos");
                return new ValidationErrorsResult();
            }

            var token = TokenHelper.GenerateToke(usr);
            var loginResult = new Login { User = usr, Token = token };

            return new OkResult<Login>(true, 1, loginResult);
        }
    }
}

