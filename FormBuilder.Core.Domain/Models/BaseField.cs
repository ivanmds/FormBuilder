namespace FormBuilder.Core.Domain.Models
{
    public abstract class BaseField<TValue>
    {
        public string Name { get; protected set; }
        public TValue Value { get; protected set; }

        public virtual void SetValue(TValue value)
        {
            Value = value;
        }
    }
}
