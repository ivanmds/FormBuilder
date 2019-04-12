using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Forms.Response;
using System.Threading.Tasks;

namespace FormBuilder.Core.Domain.Interfaces.Commands.Forms
{
    public interface IFormResponseCommand
    {
        Task<ValidationResult> AddAsync(FormResponse formResponse);
        ValidationResult Update(FormResponse formResponse);
        Task RemoveAsync(int id);
    }
}
