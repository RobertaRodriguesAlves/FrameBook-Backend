using Framebook.Domain.Models;
using Framebook.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Framebook.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Professional> Profissionais { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professional>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.ApplyConfiguration(new ProfessionalMap());
            modelBuilder.ApplyConfiguration(new RefreshTokenMap());
        }
    }
}
