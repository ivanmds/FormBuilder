using FormBuilder.Core.Domain.Models.Fields.Builder;

namespace FormBuilder.Core.Domain.Models.Fields.Response
{
    public abstract class FieldTypeResponse<TField, TResponse> : BaseFieldResponse
        where TField : BaseFieldBuilder
    {
        public TField FieldBuilder { get; protected set; }
        public TResponse Value { get; protected set; }

        public virtual void SetValue(TResponse value)
        {
            Value = value;
        }
    }
}
