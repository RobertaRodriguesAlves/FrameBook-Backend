﻿using Framebook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framebook.Infra.Data.EntityConfig
{
    public class StackExperienciaMap : IEntityTypeConfiguration<StackExperiencia>
    {
        public void Configure(EntityTypeBuilder<StackExperiencia> builder)
        {
            builder.ToTable("StackExperiencia");
        }
    }
}