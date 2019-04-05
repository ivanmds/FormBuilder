using FluentValidation.Results;
using FormBuilder.Core.Domain.Validations.Fields.Numbers;

namespace FormBuilder.Core.Domain.Models.Fields.Numbers
{
    public class IntField : NumberField<int?>
    {
        public IntField(string name, int? minValue = null, int? maxValue = null, bool? isRequired = null)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            IsRequired = isRequired;
        }

        public override ValidationResult Validate()
        {
            return new IntFieldValidation().Validate(this);
        }
    }
}
