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

        public async Task AddAsync(FormBuild formBuild)
        {
            await _repository.AddAsync(formBuild);
        }
        public void Update(FormBuild formBuild)
        {
            _repository.Update(formBuild);
        }
        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
