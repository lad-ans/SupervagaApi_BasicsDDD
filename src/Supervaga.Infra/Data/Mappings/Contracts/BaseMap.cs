using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Infra.Data.Mappings.Contracts
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public BaseMap(string tableName)
        {
            this._tablename = tableName;
        }
        private readonly string _tablename;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tablename)) builder.ToTable(_tablename);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Id).IsUnique(false);
        }
    }
}