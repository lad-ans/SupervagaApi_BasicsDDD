using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Auth.Commands;
using Supervaga.Domain.Auth.Handlers;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;
using Supervaga.Domain.Users.Commands;

namespace Domain.Users.Handlers
{
    public class CreateUserHandler : IHandler<CreateUserCommand>
    {
        public CreateUserHandler(
            IRepository<User> repository,
            LoginHandler loginHandler,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _loginHandler = loginHandler;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<User> _repository;
        private readonly LoginHandler _loginHandler;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(CreateUserCommand command, object? data = null)
        {
            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var userExist = (await _repository.Get()).Any(x => x.Email?.ToLower() == command.Email!.ToLower());
            if (userExist)
            {
                _notificationContext.AddNotification("EmailExists", "Este Email existe em nossa base de dados! Informe outro.");
                return new ValidationErrorsResult();
            }

            var user = new User(
                command.Avatar!,
                command.Name!,
                command.Password!,
                command.Phone!,
                command.Address!,
                command.Biography!,
                command.Email!,
                command.Type!,
                command.Gender!,
                command.Provider!,
                command.Cv!,
                command.Tag!,
                command.Role!
            );
            await _repository.Create(user);
            var loginResult = await _loginHandler.Handle(new LoginCommand(user.Email!, user.Password!));

            return loginResult;
        }

    }
}