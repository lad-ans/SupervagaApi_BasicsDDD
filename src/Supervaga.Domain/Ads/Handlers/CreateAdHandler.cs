using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Ads.Commands;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users;

namespace Domain.Ads.Handlers
{
    public class CreateAdHandler : IHandler<CreateAdCommand>
    {
        public CreateAdHandler(
            IRepository<Ad> repository,
            IRepository<User> userRepository,
            IRepository<Application> applicationRepository,
            NotificationContext notificationContext
        )
        {
            _repository = repository;
            _userRepository = userRepository;
            _applicationRepository = applicationRepository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<Ad> _repository;
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly NotificationContext _notificationContext;

        public async Task<IResult> Handle(CreateAdCommand command, object? data = null)
        {
            command.Validate();
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var usr = await _userRepository.Get(command.UserId);
            if (usr == null)
            {
                _notificationContext.AddNotification("UserNotFound", "Usuário não encontrado");
                return new ValidationErrorsResult();
            }

            var ad = new Ad(
                command.Title!,
                command.Category!,
                command.Description!,
                command.Address!,
                command.AudienceGender!,
                command.ExpiresAt,
                command.Advantages!,
                command.Requirements!,
                command.SalaryOffer,
                command.IsFreelance
            );

            var application = new Application(ad.Id, ad.ExpiresAt, new List<Candidate>());
            ad.ApplicationId = application.Id;
            ad.UserId = usr.Id;

            await _repository.Create(ad);
            await _applicationRepository.Create(application);
            ad.User = usr;

            return new OkResult<Ad>(true, 1, ad);
        }

    }
}