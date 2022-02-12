using Domain.Shared.Contracts.Handlers;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Candidates.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;

namespace Domain.Applications.Handlers
{
    public class CreateCandidateHandler : IHandler<CreateCandidateCommand>
    {
        public CreateCandidateHandler(
            NotificationContext notificationContext,
            IRepository<Candidate> repository
        )
        {
            _notificationContext = notificationContext;
            _repository = repository;
        }

        private readonly NotificationContext _notificationContext;
        private readonly IRepository<Candidate> _repository;
        public async Task<IResult> Handle(CreateCandidateCommand command, object? data = null)
        {
            await Task.Delay(0);

            var notUnique = (await _repository.Get()).Any(
                x => x.UserId == command.UserId && x.AdId == command.AdId
            );

            command.Validate(!notUnique);
            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command.ValidationResult!);
                return new ValidationErrorsResult();
            }

            var candidate = new Candidate(
                command.ApplicationId,
                command.AdId,
                command.UserId,
                command.Status!,
                isCv: command.IsCv
            );

            var result = new OkResult<Candidate>(true, 1, candidate);
            return result;
        }

    }

}