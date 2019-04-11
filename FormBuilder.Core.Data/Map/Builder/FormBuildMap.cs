using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map.Builder
{
    public class FormBuildMap : IEntityTypeConfiguration<FormBuild>
    {
        public void Configure(EntityTypeBuilder<FormBuild> builder)
        {
            builder.ToTable("FormBuild");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
