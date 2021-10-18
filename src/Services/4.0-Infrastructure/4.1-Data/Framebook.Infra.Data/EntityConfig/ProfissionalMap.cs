using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("Profissional");

            builder.HasKey(x => x.Email);

            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Uf).HasMaxLength(2).IsFixedLength();
            builder.Property(p => p.Cidade).HasMaxLength(250);
            builder.Property(p => p.Telefone).HasMaxLength(120);
            builder.Property(p => p.Senha).HasMaxLength(120);
        }
    }
}
