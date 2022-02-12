using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Ads;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class AdvantageMap : BaseMap<Advantage>
    {
        public AdvantageMap() : base("tb_advantage")
        {
        }

        public override void Configure(EntityTypeBuilder<Advantage> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasColumnName("title");

            builder.Property(x => x.AdId).HasColumnName("ad_id");
            builder.HasOne(x => x.Ad).WithMany(x => x.Advantages).HasForeignKey(x => x.AdId);

            builder.HasIndex(x => x.Title);
        }
    }
}