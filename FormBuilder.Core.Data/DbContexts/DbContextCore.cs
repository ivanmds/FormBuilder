using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Data.Map.Builder;
using FormBuilder.Core.Data.Map.Response;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;

namespace FormBuilder.Core.Data.DbContexts
{
    public class DbContextCore : DbContext
    {
        public DbSet<FormBuild> FormBuilds { get; set; }
        public DbSet<TextFieldBuilder> TextFieldBuilders { get; set; }
        public DbSet<IntFieldBuilder> IntFieldBuilders { get; set; }

        public DbSet<FormResponse> FormResponses { get; set; }
        public DbSet<IntFieldResponse> IntFieldResponses { get; set; }
        public DbSet<TextFieldResponse> TextFieldResponses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Builders
            modelBuilder.ApplyConfiguration(new FormBuildMap());
            modelBuilder.ApplyConfiguration(new BaseFieldBuilderMap());
            modelBuilder.ApplyConfiguration(new TextFieldBuilderMap());
            modelBuilder.ApplyConfiguration(new IntFieldBuilderMap());
            #endregion

            //#region Responses
            modelBuilder.ApplyConfiguration(new BaseFieldResponseMap());
            modelBuilder.ApplyConfiguration(new IntFieldResponseMap());
            modelBuilder.ApplyConfiguration(new TextFieldResponseMap());
            modelBuilder.ApplyConfiguration(new FormResponseMap());
            //#endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLServer;Initial Catalog=FormBuilder;Persist Security Info=True;User ID=sa;Password=123456");
        }
    }
}
