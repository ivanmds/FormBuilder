using System.Threading.Tasks;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Models.Forms.Response;

namespace FormBuilder.Core.Data.Repositories.Forms
{
    public class FormResponseRepository : IFormResponseRepository
    {
        public async Task<FormResponse> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(FormResponse formResponse)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(FormResponse formResponse)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
