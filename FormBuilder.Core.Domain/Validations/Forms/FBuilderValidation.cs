using FluentValidation;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Validations.Forms
{
    public class FBuilderValidation : AbstractValidator<FBuilder>
    {
        public FBuilderValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .Must(name => name?.Trim().Length > 0)
                .WithMessage("Name is not valid.");
        }
    }
}
