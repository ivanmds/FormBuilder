using FluentValidation.Results;
using FormBuilder.Core.Domain.Validations;

namespace FormBuilder.Core.Domain.Models
{
    public class TextField : BaseField<string>
    {
        public TextField(string name, int? minLength = null, int? maxLength = null, bool? isRequired = null, string placeholder = null)
        {
            Name = name;
            MinLength = minLength;
            MaxLength = maxLength;
            IsRequired = isRequired;
            Placeholder = placeholder;
        }

        public int? MinLength { get; private set; }
        public int? MaxLength { get; private set; }
        public string Placeholder { get; private set; }

        public override void SetValue(string value)
        {
            if (value != null) value = value.Trim();
            base.SetValue(value);
        }

        public override ValidationResult IsValid()
        {
            return new TextFieldValidation().Validate(this);
        }
    }
}
