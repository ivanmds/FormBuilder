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

        public ValidationResult Update(FormResponse formResponse)
        {
            ValidationResult result = formResponse.Validate();

            if (result.IsValid)
                _repository.Update(formResponse);

            return result;
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
