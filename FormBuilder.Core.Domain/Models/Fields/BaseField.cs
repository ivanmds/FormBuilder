using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;

namespace FormBuilder.Core.Domain.Models.Fields
{
    public abstract class BaseField : IValidable
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public bool? IsRequired { get; protected set; }
        public int Order { get; protected set; }

        public abstract ValidationResult Validate();
    }
}
