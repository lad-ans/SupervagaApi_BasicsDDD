using Supervaga.Domain.Applications.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Applications.Commands
{
    public class UpdateApplicationCommand : Command
    {
        public UpdateApplicationCommand()
        {
        }

        public UpdateApplicationCommand(
            Guid adId,
            DateTime expiresAt,
            IList<Candidate>? candidates
        )
        {
            AdId = adId;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.Now;
            Candidates = candidates;
        }
        public Guid Id { get; set; }
        public Guid AdId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Candidate>? Candidates { get; set; }

        public UpdateApplicationCommand CopyWith(Guid id, Application application)
        {
            UpdateApplicationCommand newCommand = new UpdateApplicationCommand
            {
                AdId = application.AdId,
                ExpiresAt = _getExpiresAt(application),
                Candidates = this.Candidates ?? application.Candidates,
            };
            newCommand.Id = id;

            return newCommand;
        }

        DateTime _getExpiresAt(Application application) =>
            this.ExpiresAt.CompareTo(application.ExpiresAt) != 0
            && this.ExpiresAt.CompareTo(application.CreatedAt) > 0
                ? this.ExpiresAt
                : application.ExpiresAt;

        public void Validate() => Validate(this, new UpdateApplicationCommandValidator());
    }

}