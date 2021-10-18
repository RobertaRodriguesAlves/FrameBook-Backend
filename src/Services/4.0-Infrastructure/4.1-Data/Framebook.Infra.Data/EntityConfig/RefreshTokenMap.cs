using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class RefreshTokenMap : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshToken");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Token).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Expires).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(100);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.CreatedByIp).HasMaxLength(50);
            builder.Property(p => p.RevokedByIp).HasMaxLength(50);
            builder.Property(p => p.ReplaceByToken).HasMaxLength(500);
        }
    }
}
