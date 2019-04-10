using FluentValidation.Results;
using FormBuilder.Core.Domain.Validations.Fields.Texts;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;

namespace FormBuilder.Core.Domain.Models.Fields.Response.Texts
{
    public class TextFieldResponse : FieldTypeResponse<TextFieldBuilder, string>
    {
        protected TextFieldResponse() { }
        public TextFieldResponse(TextFieldBuilder field)
        {
            FieldBuilder = field;
        }

        public override void SetValue(string value)
        {
            if (value != null) value = value.Trim();
            base.SetValue(value);
        }

        public override ValidationResult Validate()
        {
            return new TextFieldValidation().Validate(this);
        }
    }
}
