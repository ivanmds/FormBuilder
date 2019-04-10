using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;

namespace FormBuilder.Core.Data.Map.Builder
{
    public class IntFieldBuilderMap : IEntityTypeConfiguration<IntFieldBuilder>
    {
        public void Configure(EntityTypeBuilder<IntFieldBuilder> builder)
        {
            builder.ToTable("IntField");
        }
    }
}
