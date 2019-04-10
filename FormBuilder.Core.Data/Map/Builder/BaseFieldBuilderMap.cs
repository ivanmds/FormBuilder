using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Fields.Builder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map.Builder
{
    public class BaseFieldBuilderMap : IEntityTypeConfiguration<BaseFieldBuilder>
    {
        public void Configure(EntityTypeBuilder<BaseFieldBuilder> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
