using Supervaga.Domain.Applications.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Candidates.Commands
{
    public class CreateCandidateCommand : Command
    {
        public CreateCandidateCommand()
        {
        }

        public CreateCandidateCommand(
            Guid applicationId,
            Guid adId,
            Guid userId,
            string? status,
            DateTime createdAt,
            bool isCv
        )
        {
            ApplicationId = applicationId;
            AdId = adId;
            UserId = userId;
            Status = status;
            CreatedAt = createdAt;
            IsCv = isCv;
        }

        public Guid ApplicationId { get; private set; }
        public Guid AdId { get; private set; }
        public Guid UserId { get; private set; }
        public string? Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsCv { get; private set; }

        public void Validate(bool unique) => Validate(this, new CreateCandidateCommandValidator(unique));
    }

}