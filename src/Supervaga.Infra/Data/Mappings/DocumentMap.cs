using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Documents;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class DocumentMap : BaseMap<Document>
    {
        public DocumentMap() : base("tb_document")
        {
        }

        public override void Configure(EntityTypeBuilder<Document> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FileName).HasColumnName("file_name").HasMaxLength(500);
            builder.Property(x => x.FileSize).HasColumnName("file_size").HasMaxLength(100);
            builder.Property(x => x.ContentType).HasColumnName("content_type");

            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.FileName);
        }
    }
}