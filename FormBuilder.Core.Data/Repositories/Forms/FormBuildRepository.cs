using System.Threading.Tasks;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;

namespace FormBuilder.Core.Data.Repositories.Forms
{
    public class FormBuildRepository : IFormBuildRepository
    {
        protected readonly DbContextCore _dbContext;

        public FormBuildRepository(DbContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FormBuild> FindAsync(int id)
        {
            return await _dbContext.FormBuilds.FindAsync(id);
        }

        public async Task AddAsync(FormBuild fBuilder)
        {
            await _dbContext.FormBuilds.AddAsync(fBuilder);
        }

        public void Update(FormBuild fBuilder)
        {
            _dbContext.FormBuilds.Update(fBuilder);
        }

        public async Task RemoveAsync(int id)
        {
            FormBuild formBuild = await FindAsync(id);
            _dbContext.FormBuilds.Remove(formBuild);
        }
    }
}
