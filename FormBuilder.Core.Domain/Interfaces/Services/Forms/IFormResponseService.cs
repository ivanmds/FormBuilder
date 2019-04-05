using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Forms.Response;
using System.Threading.Tasks;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFormResponseService
    {
        Task<FormResponse> GetAsync(int id);
        Task<ValidationResult> AddAsync(FormResponse formResponse);
        Task<ValidationResult> UpdateAsync(FormResponse formResponse);
        Task DeleteAsync(int id);
    }
}
