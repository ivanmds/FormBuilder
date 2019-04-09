﻿using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map
{
    public class FormBuildMap : IEntityTypeConfiguration<FormBuild>
    {
        public void Configure(EntityTypeBuilder<FormBuild> builder)
        {
            builder.ToTable("FormBuild");
            builder.HasKey(p => p.Id);
        }
    }
}
