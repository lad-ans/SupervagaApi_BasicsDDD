using Supervaga.Domain.Ads.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Ads.Commands
{
    public class CreateAdCommand : Command
    {
        public CreateAdCommand()
        {
        }

        public CreateAdCommand(
            Guid userId,
            string? title,
            string? category,
            string? description,
            string? address,
            string? audienceGender,
            DateTime createdAt,
            DateTime expiresAt,
            bool isFreelance,
            IList<Advantage>? advantages,
            IList<Requirement>? requirements,
            float? salaryOffer
        )
        {
            UserId = userId;
            Title = title;
            Category = category;
            Description = description;
            Address = address;
            AudienceGender = audienceGender;
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;
            IsFreelance = isFreelance;
            Advantages = advantages;
            Requirements = requirements;
            SalaryOffer = salaryOffer;
        }

        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? AudienceGender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsFreelance { get; set; }
        public IList<Advantage>? Advantages { get; set; }
        public IList<Requirement>? Requirements { get; set; }
        public float? SalaryOffer { get; set; }

        public void Validate() => Validate(this, new CreateAdCommandValidator());
    }

}