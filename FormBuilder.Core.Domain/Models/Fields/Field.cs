namespace FormBuilder.Core.Domain.Models.Fields
{
    public abstract class Field<TValue> : BaseField
    {
        public TValue Value { get; protected set; }
        public virtual void SetValue(TValue value)
        {
            Value = value;
        }
    }
}
