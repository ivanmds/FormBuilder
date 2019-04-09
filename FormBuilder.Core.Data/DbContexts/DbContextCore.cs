using FormBuilder.Core.Data.Map;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;

namespace FormBuilder.Core.Data.DbContexts
{
    public class DbContextCore : DbContext
    {
        public DbSet<FormBuild> FormBuilds { get; set; }
        //public DbSet<FormResponse> FormResponses { get; set; }
        public DbSet<TextFieldBuilder> TextFields { get; set; }
        public DbSet<IntFieldBuilder> IntFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormBuildMap());
            modelBuilder.ApplyConfiguration(new TextFieldMap());
            modelBuilder.ApplyConfiguration(new IntFieldMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLServer;Initial Catalog=FormBuilder;Persist Security Info=True;User ID=sa;Password=123456");
        }
    }
}
