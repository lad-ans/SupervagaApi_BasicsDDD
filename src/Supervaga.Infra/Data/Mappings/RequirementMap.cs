using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Ads;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class RequirementMap : BaseMap<Requirement>
    {
        public RequirementMap() : base("tb_requirement")
        {
        }

        public override void Configure(EntityTypeBuilder<Requirement> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasColumnName("title");

            builder.Property(x => x.AdId).HasColumnName("ad_id");
            builder.HasOne(x => x.Ad).WithMany(x => x.Requirements).HasForeignKey(x => x.AdId);

            builder.HasIndex(x => x.Title);
        }
    }
}