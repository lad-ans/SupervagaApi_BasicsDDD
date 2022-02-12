using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Applications.Commands;
using Supervaga.Domain.Candidates.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;

namespace Domain.Applications.Handlers
{
    public class UpdateApplicationHandler : IHandler<UpdateApplicationCommand>
    {
        public UpdateApplicationHandler(
            IRepository<Application> applicationRepository,
            IRepository<Ad> adRepository,
            IRepository<Candidate> candidateRepository,
            NotificationContext notificationContext
        )
        {
            _applicationRepository = applicationRepository;
            _adRepository = adRepository;
            _candidateRepository = candidateRepository;
            _notificationContext = notificationContext;
        }

        private readonly IRepository<Ad> _adRepository;
        private readonly IRepository<Candidate> _candidateRepository;
        private readonly IRepository<Application> _applicationRepository;
        private readonly NotificationContext _notificationContext;
        public async Task<IResult> Handle(UpdateApplicationCommand command, object? data)
        {
            var id = (Guid)data!;
            var app = await _applicationRepository.Get(id);

            if (app.Ad == null)
            {
                _notificationContext.AddNotification(
                    "ApplicationNotFound",
                    "Candidatura não encontrada"
                );
                return new ValidationErrorsResult();
            }

            var newCmd = command.CopyWith(id, app);
            newCmd.Validate();

            if (newCmd.Invalid)
            {
                _notificationContext.AddNotifications(newCmd.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var candidates = (await _applicationRepository.Get(newCmd.Id)).Candidates ?? new List<Candidate>();
            if (newCmd.Candidates != null && newCmd.Candidates.Count > 0)
                foreach (var c in newCmd.Candidates!.ToList())
                {
                    var r = await _getCommandByEntity(c);
                    if (r is ValidationErrorsResult)
                        return new ValidationErrorsResult();
                    else
                    {
                        var cand = (OkResult<Candidate>?)r;
                        candidates.Add(cand?.Data!);
                    }
                }

            var application = new Application(
                newCmd.AdId,
                newCmd.ExpiresAt,
                candidates
            );
            application.Id = newCmd.Id;
            await _applicationRepository.Update(application);

            return new OkResult<Application>(true, 1, application);
        }

        #region Helper
        async Task<IResult?> _getCommandByEntity(Candidate c)
        {
            var cmd = new CreateCandidateCommand(
                c.ApplicationId,
                c.AdId,
                c.UserId,
                c.Status!,
                c.CreatedAt,
                c.IsCv
            );
            var handler = new CreateCandidateHandler(_notificationContext, _candidateRepository);
            var result = await handler.Handle(cmd);

            return result;
        }
        #endregion

    }

}