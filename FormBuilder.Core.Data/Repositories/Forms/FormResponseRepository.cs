using System.Threading.Tasks;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Models.Forms.Response;

namespace FormBuilder.Core.Data.Repositories.Forms
{
    public class FormResponseRepository : IFormResponseRepository
    {
        public Task AddAsync(FormResponse formResponse)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<FormResponse> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(FormResponse formResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}
