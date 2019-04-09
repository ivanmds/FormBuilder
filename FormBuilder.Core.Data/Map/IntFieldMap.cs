using FormBuilder.Core.Domain.Models.Fields.Numbers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map
{
    public class IntFieldMap : IEntityTypeConfiguration<IntField>
    {
        public void Configure(EntityTypeBuilder<IntField> builder)
        {
            builder.ToTable("IntField");
        }
    }
}
