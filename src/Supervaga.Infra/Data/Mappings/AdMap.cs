using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Ads;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class AdMap : BaseMap<Ad>
    {
        public AdMap() : base("tb_ad")
        {
        }

        public override void Configure(EntityTypeBuilder<Ad> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.Category).HasColumnName("category");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Address).HasColumnName("address");
            builder.Property(x => x.AudienceGender).HasColumnName("audience_gender");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ExpiresAt).HasColumnName("expires_at");
            builder.Property(x => x.IsFreelance).HasColumnName("is_freelance").HasDefaultValue(false);
            builder.Property(x => x.SalaryOffer).HasColumnName("salary_offer");
            builder.Property(x => x.ApplicationId).HasColumnName("application_id");
            
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.HasOne(x => x.User).WithOne().HasForeignKey<Ad>(x => x.UserId).HasConstraintName("FK_tb_user_user_id");

            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.Category);
            builder.HasIndex(x => x.Description);
            builder.HasIndex(x => x.UserId).IsUnique(false);
        }
    }
}