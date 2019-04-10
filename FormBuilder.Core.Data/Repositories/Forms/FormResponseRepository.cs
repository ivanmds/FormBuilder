using System.Threading.Tasks;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;

namespace FormBuilder.Core.Data.Repositories.Forms
{
    public class FormResponseRepository : IFormResponseRepository
    {
        private readonly DbContextCore _dbContext;

        public FormResponseRepository(DbContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FormResponse> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(FormResponse formResponse)
        {
            await _dbContext.FormResponses.AddAsync(formResponse);
        }

        public void Update(FormResponse formResponse)
        {
            _dbContext.FormResponses.Update(formResponse);
        }

        public async Task RemoveAsync(int id)
        {
            FormResponse formResponse = await GetAsync(id);
            _dbContext.FormResponses.Remove(formResponse);
        }
    }
}
