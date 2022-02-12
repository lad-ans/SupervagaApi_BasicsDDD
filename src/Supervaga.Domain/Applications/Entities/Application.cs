using Supervaga.Domain.Ads;
using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Domain.Applications
{
    public class Application : Entity
    {
        public Application()
        {
        }
        public Application(
            Guid adId,
            DateTime expiresAt,
            IList<Candidate> candidates
        )
        {
            AdId = adId;
            CreatedAt = DateTime.Now;
            ExpiresAt = expiresAt;
            Candidates = candidates;
        }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public IList<Candidate>? Candidates { get; set; }

        public Guid AdId { get; private set; }
        public Ad? Ad { get; set; }
    }
}