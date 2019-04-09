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
            RuleFor(p => p.Field)
                .NotNull();
        }

        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
                .Must(value =>
                {
                    return value.HasValue;
                })
                .When(p => p.Field != null && p.Field.IsRequired == true)
                .WithMessage("Value is required.");
        }

        private void ValidateMinValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return value >= response.Field.MinValue.Value;
                })
                .When(p => p.Field != null && p.Field.MinValue != null)
                .WithMessage("Min value is required.");
        }

        private void ValidateMaxValue()
        {
            RuleFor(p => p.Value)
                .Must((response, value) =>
                {
                    return value <= response.Field.MaxValue.Value;
                })
                .When(p => p.Field != null && p.Field.MaxValue != null)
                .WithMessage("Max value is required.");
        }
    }
}
