using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Ads.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;

namespace Domain.Ads.Handlers
{
    public class UpdateAdHandler : IHandler<UpdateAdCommand>
    {
        public UpdateAdHandler(
            IRepository<Ad> repository,
            IRepository<User> userRepository,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _userRepository = userRepository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<Ad> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly NotificationContext _notificationContext;
        public async Task<IResult> Handle(UpdateAdCommand command, object? data)
        {
            var id = (Guid)data!;
            var _ad = await _repository.Get(id);

            if (_ad == null)
            {
                _notificationContext.AddNotification("AdNotFound", "Vaga não encontrada");
                return new ValidationErrorsResult();
            }

            var newCmd = command.CopyWith(id, _ad);
            newCmd.Validate();

            if (newCmd.Invalid)
            {
                _notificationContext.AddNotifications(newCmd.ValidationResult!);
                return new ValidationErrorsResult();
            }


            var user = await _userRepository.Get(newCmd.UserId);
            var ad = new Ad(
                newCmd.Title!,
                newCmd.Category!,
                newCmd.Description!,
                newCmd.Address!,
                newCmd.AudienceGender!,
                newCmd.ExpiresAt!,
                newCmd.Advantages!,
                newCmd.Requirements!,
                newCmd.SalaryOffer,
                newCmd.IsFreelance
            );
            ad.Id = _ad.Id;
            ad.User = user;
            ad.UserId = user.Id;
            ad.ApplicationId = _ad.ApplicationId;
            await _repository.Update(_ad.Copy(ad));

            return new OkResult<Ad>(true, 1, _ad.Copy(ad));
        }

    }
}