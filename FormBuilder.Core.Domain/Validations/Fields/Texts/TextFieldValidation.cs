using FluentValidation;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;

namespace FormBuilder.Core.Domain.Validations.Fields.Texts
{
    public class TextFieldValidation : AbstractValidator<TextFieldResponse>
    {
        public TextFieldValidation()
        {
            ValidateField();
            ValidateIsRequired();
            ValidateMinLenght();
            ValidateMaxLenght();
        }

        private void ValidateField()
        {
            RuleFor(p => p.Field)
                .NotNull();
        }
        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
               .Must((response, value) => {
                   return !string.IsNullOrEmpty(value);
               })
               .When(p => p.Field != null && p.Field.IsRequired == true)
               .WithMessage("Field is required");
        }

        private void ValidateMinLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return response.Field?.MinLength > 0 && value.Length >= response.Field.MinLength.Value;
                })
                .When(p => p.Field != null && p.Field.MinLength != null)
                .WithMessage("Field required min length");
        }

        private void ValidateMaxLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return response.Field?.MaxLength > 0 && value.Length < response.Field.MaxLength;
                })
                .When(p => p.Field != null && p.Field.MaxLength != null)
                .WithMessage("Field is required max lenght");
        }
    }
}
