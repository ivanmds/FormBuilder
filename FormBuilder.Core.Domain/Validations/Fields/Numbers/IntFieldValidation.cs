using FluentValidation;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;

namespace FormBuilder.Core.Domain.Validations.Fields.Numbers
{
    public class IntFieldValidation : AbstractValidator<IntFieldResponse>
    {
        public IntFieldValidation()
        {
            ValidateField();
            ValidateIsRequired();
            ValidateMinValue();
            ValidateMaxValue();
        }

        private void ValidateField()
        {
            RuleFor(p => p.FieldBuild)
                .NotNull();
        }

        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
                .Must(value =>
                {
                    return value.HasValue;
                })
                .When(p => p.FieldBuild != null && p.FieldBuild.IsRequired == true)
                .WithMessage("Value is required.");
        }

        private void ValidateMinValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    IntFieldBuilder fieldBuilder = response.GetFieldBuilder();
                    return value >= fieldBuilder?.MinValue.Value;
                })
                .When(p => p.FieldBuild != null && p.GetFieldBuilder()?.MinValue != null)
                .WithMessage("Min value is required.");
        }

        private void ValidateMaxValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    IntFieldBuilder fieldBuilder = response.GetFieldBuilder();
                    return value <= fieldBuilder?.MaxValue.Value;
                })
                .When(p => p.FieldBuild != null && p.GetFieldBuilder()?.MaxValue != null)
                .WithMessage("Max value is required.");
        }
    }
}
