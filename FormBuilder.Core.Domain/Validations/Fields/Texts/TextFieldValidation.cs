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
            RuleFor(p => p.FieldBuilder)
                .NotNull();
        }
        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
               .Must((response, value) => {
                   return !string.IsNullOrEmpty(value);
               })
               .When(p => p.FieldBuilder != null && p.FieldBuilder.IsRequired == true)
               .WithMessage("Field is required");
        }

        private void ValidateMinLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return response.FieldBuilder?.MinLength > 0 && value.Length >= response.FieldBuilder.MinLength.Value;
                })
                .When(p => p.FieldBuilder != null && p.FieldBuilder.MinLength != null)
                .WithMessage("Field required min length");
        }

        private void ValidateMaxLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return response.FieldBuilder?.MaxLength > 0 && value.Length < response.FieldBuilder.MaxLength;
                })
                .When(p => p.FieldBuilder != null && p.FieldBuilder.MaxLength != null)
                .WithMessage("Field is required max lenght");
        }
    }
}
