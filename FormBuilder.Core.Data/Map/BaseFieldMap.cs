using FormBuilder.Core.Domain.Models.Fields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map
{
    public class BaseFieldMap : IEntityTypeConfiguration<BaseField>
    {
        public void Configure(EntityTypeBuilder<BaseField> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
