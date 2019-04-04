using FluentValidation.Results;

namespace FormBuilder.Core.Domain.Validations
{
    public interface IValidated
    {
        ValidationResult IsValid();
    }
}
