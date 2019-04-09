using FormBuilder.Core.Data.Map;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Fields.Texts;
using FormBuilder.Core.Domain.Models.Fields.Numbers;

namespace FormBuilder.Core.Data.DbContexts
{
    public class DbContextCore : DbContext
    {

        public DbSet<FormBuild> FormBuilds { get; set; }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<IntField> IntFields { get; set; }

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
