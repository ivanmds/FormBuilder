using FluentValidation;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
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
            RuleFor(p => p.FieldBuild)
                .NotNull();
        }
        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
               .Must((response, value) => {
                   return !string.IsNullOrEmpty(value);
               })
               .When(p => p.FieldBuild != null && p.FieldBuild.IsRequired == true)
               .WithMessage("Field is required");
        }

        private void ValidateMinLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    TextFieldBuilder fieldBuilder = response.GetFieldBuilder();

                    return fieldBuilder?.MinLength > 0 && value.Length >= fieldBuilder?.MinLength.Value;
                })
                .When(p => p.FieldBuild != null && p.GetFieldBuilder()?.MinLength != null)
                .WithMessage("Field required min length");
        }

        private void ValidateMaxLenght()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    TextFieldBuilder fieldBuilder = response.GetFieldBuilder();
                    return fieldBuilder?.MaxLength > 0 && value.Length < fieldBuilder?.MaxLength;
                })
                .When(p => p.FieldBuild != null && p.GetFieldBuilder()?.MaxLength != null)
                .WithMessage("Field is required max lenght");
        }
    }
}
