using FormBuilder.Core.Domain.Validations;
using System;

namespace FormBuilder.Core.Domain.Models
{
    public class TextField : BaseField<string>, IValidated
    {
        public TextField(string name, int? maxLength = null, int? minLength = null, bool? isRequired = null, string placeholder = null)
        {
            Name = name;
            MaxLength = maxLength;
            MinLength = minLength;
            IsRequired = IsRequired;
            Placeholder = placeholder;
        }

        public int? MaxLength { get; private set; }
        public int? MinLength { get; private set; }
        public bool? IsRequired { get; private set; }
        public string Placeholder { get; private set; }

        public bool IsValid()
        {
            return false;
        }
    }
}
