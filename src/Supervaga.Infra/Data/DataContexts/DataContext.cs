using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Documents;
using Supervaga.Domain.Users;

namespace Supervaga.Infra.Data.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ad>? Ads { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Candidate>? Candidates { get; set; }
        public DbSet<Requirement>? Requirements { get; set; }
        public DbSet<Advantage>? Advantages { get; set; }
        public DbSet<Document>? Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly); 
        }
    }
}