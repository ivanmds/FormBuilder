using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;

namespace FormBuilder.Core.Data.Map.Response
{
    public class IntFieldResponseMap : IEntityTypeConfiguration<IntFieldResponse>
    {
        public void Configure(EntityTypeBuilder<IntFieldResponse> builder)
        {
            builder.ToTable("IntFieldResponse");

            builder.HasOne(p => p.FieldBuilder)
                .WithMany()
                .HasForeignKey("FieldBuilderId");

            builder.Property(p => p.Value)
                .HasColumnName("IntFieldValue")
                .IsRequired();
        }
    }
}
