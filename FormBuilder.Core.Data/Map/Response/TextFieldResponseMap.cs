using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;

namespace FormBuilder.Core.Data.Map.Response
{
    public class TextFieldResponseMap : IEntityTypeConfiguration<TextFieldResponse>
    {
        public void Configure(EntityTypeBuilder<TextFieldResponse> builder)
        {
            builder.ToTable("TextFieldResponse");

            builder.Property(p => p.Value)
                .HasColumnName("TextFieldValue")
                .IsRequired();
        }
    }
}
