using FormBuilder.Core.Domain.Models.Fields.Builder;

namespace FormBuilder.Core.Domain.Models.Fields.Response
{
    public abstract class FieldTypeResponse<TField, TResponse> : BaseFieldResponse
        where TField : BaseFieldBuilder
    {
        public TResponse Value { get; protected set; }

        public virtual void SetValue(TResponse value)
        {
            Value = value;
        }

        public TField GetFieldBuilder()
        {
            return FieldBuild as TField;
        }
    }
}
