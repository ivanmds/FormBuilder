using FluentValidation;
using FormBuilder.Core.Domain.Models.Forms.Builder;

namespace FormBuilder.Core.Domain.Validations.Forms
{
    public class FormBaseValidation : AbstractValidator<FormBase>
    {
        public FormBaseValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .Must(name => name?.Trim().Length > 0)
                .WithMessage("Name is not valid.");
        }
    }
}
