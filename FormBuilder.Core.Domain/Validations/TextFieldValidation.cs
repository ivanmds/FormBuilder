using FluentValidation;
using FormBuilder.Core.Domain.Models;

namespace FormBuilder.Core.Domain.Validations
{
    public class TextFieldValidation : AbstractValidator<TextField>
    {
        public TextFieldValidation()
        {
            ValidateIsRequired();
            ValidateMinLenght();
            ValidateMaxLenght();
        }

        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
               .Must((field, value) => {
                   return !string.IsNullOrEmpty(value);
               })
               .When(p => p.IsRequired == true)
               .WithMessage("Field is required");
        }

        private void ValidateMinLenght()
        {
            RuleFor(p => p.Value)
                .Must((field, value) =>
                {
                    return field?.MinLength > 0 && value.Length >= field.MinLength.Value;
                })
                .When(p => p.MinLength != null)
                .WithMessage("Field required min length");
        }

        private void ValidateMaxLenght()
        {
            RuleFor(p => p.Value)
                .Must((field, value) =>
                {
                    return field?.MaxLength > 0 && value.Length < field.MaxLength;
                })
                .When(p => p.MaxLength != null)
                .WithMessage("Field is required max lenght");
        }
    }
}
