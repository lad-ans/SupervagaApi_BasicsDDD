using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Domain.Applications
{
    public class Candidate : Entity
    {
        public Candidate()
        {
        }
        public Candidate(
            Guid applicationId,
            Guid adId,
            Guid userId,
            string status,
            bool isCv = false
        )
        {
            ApplicationId = applicationId;
            AdId = adId;
            UserId = userId;
            Status = status!;
            CreatedAt = DateTime.Now;
            IsCv = isCv;
        }

        public Guid ApplicationId { get; set; }
        public virtual Application? Application { get; set; }
        public Guid AdId { get; set; }
        public Guid UserId { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsCv { get; set; }
    }
}