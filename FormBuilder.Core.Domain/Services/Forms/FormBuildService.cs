using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Services.Forms;

namespace FormBuilder.Core.Domain.Services.Forms
{
    public class FormBuildService : IFormBuildService
    {
        private readonly IFormBuildRepository _repository;
        public FormBuildService(IFormBuildRepository repository)
        {
            _repository = repository;
        }

        public async Task<FormBuild> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
        public async Task AddAsync(FormBuild formBuild)
        {
            await _repository.AddAsync(formBuild);
        }
        public async Task UpdateAsync(FormBuild formBuild)
        {
            await _repository.UpdateAsync(formBuild);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
