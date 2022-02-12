using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Ads.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;

namespace Domain.Ads.Handlers
{
    public class DeleteAdHandler : IHandler<DeleteAdCommand>
    {
        public DeleteAdHandler(
            IRepository<Ad> repository,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<Ad> _repository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(DeleteAdCommand command, object? data)
        {
            var id = (Guid)data!;
            var _ad = await _repository.Get(id);

            if (_ad == null)
            {
                _notificationContext.AddNotification("AdNotFound", "Vaga não encontrada");
                return new ValidationErrorsResult();
            }

            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var ad = await _repository.Get(command.Id);
            await _repository.Delete(ad);

            return new OkResult<string>(true, 1, $"A vaga com Id {command.Id} foi apagada com sucesso");
        }

    }
}