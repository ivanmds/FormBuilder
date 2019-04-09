namespace FormBuilder.Core.Domain.Models.Fields.Builder.Numbers
{
    public class IntFieldBuilder : NumberFieldBuilder<int?>
    {
        public IntFieldBuilder(string name, int? minValue = null, int? maxValue = null, bool? isRequired = null)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            IsRequired = isRequired;
        }
    }
}
