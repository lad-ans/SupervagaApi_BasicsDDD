using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Domain.Ads
{
    public class Advantage : Entity
    {
        public Advantage()
        {
        }

        public Advantage(Guid adId, string title)
        {
            AdId = adId;
            Title = title;
        }

        public Guid AdId { get; set; }
        public virtual Ad? Ad { get; set; }
        public string? Title { get; set; }

    }
}