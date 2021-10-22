using Framebook.Domain.Models;
using Framebook.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Framebook.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new StackMap());
            modelBuilder.ApplyConfiguration(new RefreshTokenMap());
        }
    }
}
