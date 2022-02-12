using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;
using Supervaga.Domain.Users.Commands;

namespace Domain.Users.Handlers
{
    public class UpdateUserHandler : IHandler<UpdateUserCommand>
    {
        public UpdateUserHandler(
            IRepository<User> repository,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<User> _repository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(UpdateUserCommand command, object? data)
        {
            var id = (Guid)data!;
            var usr = await _repository.Get(id);

            if (usr == null)
            {
                _notificationContext.AddNotification("UserNotFound", "Usuário não encontrado");
                return new ValidationErrorsResult();
            }

            var newCmd = command.CopyWith(id, usr);
            newCmd.Validate();

            if (newCmd.Invalid)
            {
                _notificationContext.AddNotifications(newCmd.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var userExist = (await _repository.Get()).Any(x => x.Email?.ToLower() == newCmd.Email!.ToLower() && command.Email != null && usr.Email?.ToLower() != newCmd.Email.ToLower() );
            if (userExist)
            {
                _notificationContext.AddNotification("EmailExists", "Este Email existe em nossa base de dados! Informe outro.");
                return new ValidationErrorsResult();
            }

            var _user = await _repository.Get(newCmd.Id);
            var user = new User(
                newCmd.Avatar!,
                newCmd.Name!,
                newCmd.Password!,
                newCmd.Phone!,
                newCmd.Address!,
                newCmd.Biography!,
                newCmd.Email!,
                newCmd.Type!,
                newCmd.Gender!,
                newCmd.Provider!,
                newCmd.Cv!,
                newCmd.Tag!,
                newCmd.Role!
            );
            user.Id = _user.Id;
            await _repository.Update(_user.Copy(user));

            return new OkResult<User>(true, 1, _user.Copy(user));
        }

    }
}