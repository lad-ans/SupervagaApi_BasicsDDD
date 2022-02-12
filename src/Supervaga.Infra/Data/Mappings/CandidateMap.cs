using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Applications;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class CandidateMap : BaseMap<Candidate>
    {
        public CandidateMap() : base("tb_candidate")
        {
        }

        public override void Configure(EntityTypeBuilder<Candidate> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.IsCv).HasColumnName("is_cv").IsRequired();
            builder.Property(x => x.Status).HasColumnName("status").IsRequired();
            builder.Property(x => x.AdId).HasColumnName("id_ad").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("id_user").IsRequired();

            builder.Property(x => x.ApplicationId).HasColumnName("application_id").IsRequired();
            builder.HasOne(x => x.Application).WithMany(x => x.Candidates).HasForeignKey(x => x.ApplicationId);

            builder.HasIndex(x => x.UserId);
        }
    }
}