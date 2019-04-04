namespace FormBuilder.Core.Domain.Models.Numbers
{
    public abstract class NumberField<TValue> : BaseField<TValue>
    {
        public int? MinValue { get; protected set; }
        public int? MaxValue { get; protected set; }
    }
}
