using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;
using Supervaga.Domain.Users.Commands;

namespace Domain.Users.Handlers
{
    public class DeleteUserHandler : IHandler<DeleteUserCommand>
    {
        public DeleteUserHandler(
            IRepository<User> repository,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<User> _repository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(DeleteUserCommand command, object? data)
        {
            var id = (Guid)data!;
            var usr = await _repository.Get(id);

            if (usr == null)
            {
                _notificationContext.AddNotification("UserNotFound", "Usuário não encontrado");
                return new ValidationErrorsResult();
            }

            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var user = await _repository.Get(command.Id);
            await _repository.Delete(user);

            return new OkResult<string>(true, 1, $"Usuário {command.Id} foi apagado com sucesso");
        }

    }
}