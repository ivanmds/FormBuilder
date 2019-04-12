namespace FormBuilder.Core.Application.ViewModels.Fields.Builder
{
    public class BaseFieldBuilderVM
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public bool? IsRequired { get; protected set; }
        public int Order { get; protected set; }
    }
}
