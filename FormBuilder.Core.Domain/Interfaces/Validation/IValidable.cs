using FluentValidation.Results;
namespace FormBuilder.Core.Domain.Interfaces.Validation
{
    public interface IValidable
    {
        ValidationResult Validate();
    }
}
