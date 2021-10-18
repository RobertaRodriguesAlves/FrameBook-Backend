using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Framebook.Domain.Models;

namespace Framebook.Infra.Data.EntityConfig
{
    public class StackMap : IEntityTypeConfiguration<Stack>
    {
        public void Configure(EntityTypeBuilder<Stack> builder)
        {
            builder.ToTable("Stack");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
