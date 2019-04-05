using System.Threading.Tasks;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Services.Forms;
using FormBuilder.Core.Domain.Models.Forms.Response;

namespace FormBuilder.Core.Domain.Services.Forms
{
    public class FormResponseService : IFormResponseService
    {
        private readonly IFormResponseRepository _repository;

        public FormResponseService(IFormResponseRepository repository)
        {
            _repository = repository;
        }

        public async Task<FormResponse> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<ValidationResult> AddAsync(FormResponse formResponse)
        {
            ValidationResult result = formResponse.Validate();

            if (result.IsValid)
                await _repository.AddAsync(formResponse);

            return result;
        }

        public async Task<ValidationResult> UpdateAsync(FormResponse formResponse)
        {
            ValidationResult result = formResponse.Validate();

            if (result.IsValid)
                await _repository.UpdateAsync(formResponse);

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
