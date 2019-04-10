using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;

namespace FormBuilder.Core.Data.Map.Builder
{
    public class TextFieldBuilderMap : IEntityTypeConfiguration<TextFieldBuilder>
    {
        public void Configure(EntityTypeBuilder<TextFieldBuilder> builder)
        {
            builder.ToTable("TextField");
        }
    }
}
