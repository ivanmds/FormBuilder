using System.Threading.Tasks;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Data.Repositories.Forms
{
    public class FormBuildRepository : IFormBuildRepository
    {
        public Task AddAsync(FormBuild fBuilder)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<FormBuild> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(FormBuild fBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}
