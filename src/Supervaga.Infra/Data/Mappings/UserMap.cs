using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supervaga.Domain.Users;
using Supervaga.Infra.Data.Mappings.Contracts;

namespace Supervaga.Infra.Data.Mappings
{
    public class UserMap : BaseMap<User>
    {
        public UserMap() : base("tb_user")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder) {
            base.Configure(builder);

            builder.Property(x => x.Avatar).HasColumnName("avatar");
            builder.Property(x =>  x.Name).HasColumnName("name").IsRequired();
            builder.Property(x =>  x.Password).HasColumnName("password");
            builder.Property(x =>  x.Phone).HasColumnName("phone");
            builder.Property(x =>  x.Address).HasColumnName("address");
            builder.Property(x =>  x.Biography).HasColumnName("biography");
            builder.Property(x =>  x.Email).HasColumnName("email").IsRequired();
            builder.Property(x =>  x.Type).HasColumnName("type");
            builder.Property(x =>  x.Gender).HasColumnName("gender");
            builder.Property(x =>  x.Provider).HasColumnName("provider");
            builder.Property(x =>  x.Cv).HasColumnName("cv");
            builder.Property(x =>  x.Tag).HasColumnName("tag");
            builder.Property(x =>  x.Role).HasColumnName("role");

            // Indexes
            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.Name);
        }
    }
}