using System;

namespace FormBuilder.Core.Domain.Models.Fields.Builder
{
    public abstract class FieldTypeBuilder<TResponse> : BaseFieldBuilder
    {
        public Type TypeResponse => typeof(TResponse);
    }
}
