using FormBuilder.Core.Domain.Models.Forms.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map
{
    public class FormResponseMap : IEntityTypeConfiguration<FormResponse>
    {
        public void Configure(EntityTypeBuilder<FormResponse> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
