using FluentValidation;
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
            RuleFor(p => p.FieldBuilder)
                .NotNull();
        }

        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
                .Must(value =>
                {
                    return value.HasValue;
                })
                .When(p => p.FieldBuilder != null && p.FieldBuilder.IsRequired == true)
                .WithMessage("Value is required.");
        }

        private void ValidateMinValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return value >= response.FieldBuilder.MinValue.Value;
                })
                .When(p => p.FieldBuilder != null && p.FieldBuilder.MinValue != null)
                .WithMessage("Min value is required.");
        }

        private void ValidateMaxValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return value <= response.FieldBuilder.MaxValue.Value;
                })
                .When(p => p.FieldBuilder != null && p.FieldBuilder.MaxValue != null)
                .WithMessage("Max value is required.");
        }
    }
}
