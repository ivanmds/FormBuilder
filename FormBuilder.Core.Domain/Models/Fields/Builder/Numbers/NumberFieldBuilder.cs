namespace FormBuilder.Core.Domain.Models.Fields.Builder.Numbers
{
    public abstract class NumberFieldBuilder<TResponse> : FieldTypeBuilder<TResponse>
    {
        public int? MinValue { get; protected set; }
        public int? MaxValue { get; protected set; }
    }
}
