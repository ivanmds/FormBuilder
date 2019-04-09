namespace FormBuilder.Core.Domain.Models.Fields.Builder.Texts
{
    public class TextFieldBuilder : FieldTypeBuilder<string>
    {
        public TextFieldBuilder(string name, int? minLength = null, int? maxLength = null, bool? isRequired = null, string placeholder = null)
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
    }
}
