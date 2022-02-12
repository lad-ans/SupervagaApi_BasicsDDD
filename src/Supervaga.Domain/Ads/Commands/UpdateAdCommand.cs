using Supervaga.Domain.Ads.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;
using Supervaga.Domain.Users;

namespace Supervaga.Domain.Ads.Commands
{
    public class UpdateAdCommand : Command
    {
        public UpdateAdCommand()
        {
        }

        public UpdateAdCommand(
            Guid userId,
            string? title,
            string? category,
            string? description,
            string? address,
            string? audienceGender,
            DateTime createdAt,
            DateTime expiresAt,
            User? user,
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
            User = user;
            IsFreelance = isFreelance;
            Advantages = advantages;
            Requirements = requirements;
            SalaryOffer = salaryOffer;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? AudienceGender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User? User { get; set; }
        public bool IsFreelance { get; set; }
        public IList<Advantage>? Advantages { get; set; }
        public IList<Requirement>? Requirements { get; set; }
        public float? SalaryOffer { get; set; }

        public UpdateAdCommand CopyWith(Guid id, Ad ad)
        {
            UpdateAdCommand newCommand = new UpdateAdCommand(
                ad.User!.Id,
                this.Title ?? ad.Title,
                this.Category ?? ad.Category,
                this.Description ?? ad.Description,
                this.Address ?? ad.Address,
                this.AudienceGender ?? ad.AudienceGender,
                ad.CreatedAt,
                _getExpiresAt(ad),
                this.User ?? ad.User,
                ad.IsFreelance,
                this.Advantages ?? ad.Advantages,
                this.Requirements ?? ad.Requirements,
                _getSalaryOffer(ad)
            );
            newCommand.Id = id;

            return newCommand;
        }

        DateTime _getExpiresAt(Ad ad) =>
            this.ExpiresAt.CompareTo(ad.ExpiresAt) != 0
            && this.ExpiresAt.CompareTo(ad.CreatedAt) > 0
                ? this.ExpiresAt
                : ad.ExpiresAt;

        float? _getSalaryOffer(Ad ad) =>
            this.SalaryOffer != null && this.SalaryOffer != ad.SalaryOffer
                ? this.SalaryOffer
                : ad.SalaryOffer;

        public void Validate() => Validate(this, new UpdateAdCommandValidator());

    }

}