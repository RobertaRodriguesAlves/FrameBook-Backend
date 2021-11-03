using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class ProfessionalMap : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("Professional");

            builder.HasKey(x => x.ProfessionalId);

            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Uf).HasMaxLength(2).IsFixedLength();
            builder.Property(p => p.Cidade).HasMaxLength(250);
            builder.Property(p => p.Telefone).HasMaxLength(120);
            builder.Property(p => p.Senha).HasMaxLength(120);
        }
    }
}
