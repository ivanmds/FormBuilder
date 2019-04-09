using FormBuilder.Core.Domain.Models.Fields.Texts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map
{
    public class TextFieldMap : IEntityTypeConfiguration<TextField>
    {
        public void Configure(EntityTypeBuilder<TextField> builder)
        {
            builder.ToTable("TextField");
        }
    }
}
