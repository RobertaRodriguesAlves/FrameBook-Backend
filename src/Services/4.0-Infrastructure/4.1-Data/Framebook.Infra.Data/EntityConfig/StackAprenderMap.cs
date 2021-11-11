using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class StackAprenderMap : IEntityTypeConfiguration<StackAprender>
    {
        public void Configure(EntityTypeBuilder<StackAprender> builder)
        {
            builder.ToTable("StackAprender");              
        }
    }
}

