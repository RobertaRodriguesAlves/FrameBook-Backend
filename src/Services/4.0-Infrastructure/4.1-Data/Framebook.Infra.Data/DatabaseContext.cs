using Framebook.Domain.Models;
using Framebook.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;

namespace Framebook.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Professional> Profissionais { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("Id_Professional").CurrentValue = Guid.NewGuid();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("Id_Professional").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professional>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.ApplyConfiguration(new ProfessionalMap());
            modelBuilder.ApplyConfiguration(new StackMap());
            modelBuilder.ApplyConfiguration(new RefreshTokenMap());
        }
    }
}
