using FluentValidation.Results;
using FormBuilder.Core.Domain.Validations;

namespace FormBuilder.Core.Domain.Models
{
    public class TextField : BaseField<string>, IValidated
    {
        public TextField(string name, int? maxLength = null, int? minLength = null, bool? isRequired = null, string placeholder = null)
        {
            Name = name;
            MaxLength = maxLength;
            MinLength = minLength;
            IsRequired = isRequired;
            Placeholder = placeholder;
        }

        public int? MaxLength { get; private set; }
        public int? MinLength { get; private set; }
        public bool? IsRequired { get; private set; }
        public string Placeholder { get; private set; }

        public override void SetValue(string value)
        {
            if (value != null) value = value.Trim();
            base.SetValue(value);
        }

        public ValidationResult IsValid()
        {
            ValidationResult result = new TextFieldValidation().Validate(this);
            return result;
        }
    }
}
