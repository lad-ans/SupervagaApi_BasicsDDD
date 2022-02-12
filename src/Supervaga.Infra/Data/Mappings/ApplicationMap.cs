using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Applications;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class ApplicationMap : BaseMap<Application>
    {
        public ApplicationMap() : base("tb_application")
        {
        }

        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.ExpiresAt).HasColumnName("expires_at").IsRequired();

            builder.Property(x => x.AdId).HasColumnName("ad_id").IsRequired();
            builder.HasOne(x => x.Ad).WithOne().HasForeignKey<Application>(x => x.AdId).HasConstraintName("FK_tb_application_ad_id_ad").IsRequired();
        }
    }
}