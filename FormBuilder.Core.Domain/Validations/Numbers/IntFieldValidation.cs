using FluentValidation;
using FormBuilder.Core.Domain.Models.Numbers;

namespace FormBuilder.Core.Domain.Validations.Numbers
{
    public class IntFieldValidation : AbstractValidator<IntField>
    {
        public IntFieldValidation()
        {
            ValidateName();
            ValidateIsRequired();
            ValidateMinValue();
            ValidateMaxValue();
        }

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.");
        }

        private void ValidateIsRequired()
        {
            RuleFor(p => p.Value)
                .Must(value =>
                {
                    return value.HasValue;
                })
                .When(p => p.IsRequired == true)
                .WithMessage("Value is required.");
        }

        private void ValidateMinValue()
        {
            RuleFor(p => p.Value)
                .Must((field, value) =>
                {
                    return value >= field.MinValue.Value;
                })
                .When(p => p.MinValue != null)
                .WithMessage("Min value is required.");
        }

        private void ValidateMaxValue()
        {
            RuleFor(p => p.Value)
                .Must((field, value) =>
                {
                    return value <= field.MaxValue.Value;
                })
                .When(p => p.MaxValue != null)
                .WithMessage("Max value is required.");
        }
    }
}
