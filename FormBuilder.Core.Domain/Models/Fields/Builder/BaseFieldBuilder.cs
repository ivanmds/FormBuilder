namespace FormBuilder.Core.Domain.Models.Fields.Builder
{
    public abstract class BaseFieldBuilder
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public bool? IsRequired { get; protected set; }
        public int Order { get; protected set; }
    }
}
