using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Forms.Response;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Core.Data.Map.Response
{
    public class FormResponseMap : IEntityTypeConfiguration<FormResponse>
    {
        public void Configure(EntityTypeBuilder<FormResponse> builder)
        {
            builder.ToTable("FormResponse");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.FormBuild);
            builder.HasMany(p => p.Fields);
        }
    }
}
