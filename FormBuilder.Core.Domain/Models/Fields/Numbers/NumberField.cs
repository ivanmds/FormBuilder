namespace FormBuilder.Core.Domain.Models.Fields.Numbers
{
    public abstract class NumberField<TValue> : Field<TValue>
    {
        public int? MinValue { get; protected set; }
        public int? MaxValue { get; protected set; }
    }
}
