using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {

        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(x => x.PerfilId);

            builder.Property(p => p.Profissional).IsRequired();

            //builder.HasOne(x => x.Profissional)
            //       .WithOne()
            //       .HasForeignKey<>
       
        }







    }
}
