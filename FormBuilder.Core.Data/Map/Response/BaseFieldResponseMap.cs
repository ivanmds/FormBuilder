using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Fields.Response;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map.Response
{
    public class BaseFieldResponseMap : IEntityTypeConfiguration<BaseFieldResponse>
    {
        public void Configure(EntityTypeBuilder<BaseFieldResponse> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
