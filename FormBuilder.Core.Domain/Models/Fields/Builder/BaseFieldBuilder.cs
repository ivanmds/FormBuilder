using FormBuilder.Shared.Kernel.Model;

namespace FormBuilder.Core.Domain.Models.Fields.Builder
{
    public abstract class BaseFieldBuilder : BaseEntity
    {
        public string Name { get; protected set; }
        public bool? IsRequired { get; protected set; }
        public int Order { get; protected set; }
    }
}
