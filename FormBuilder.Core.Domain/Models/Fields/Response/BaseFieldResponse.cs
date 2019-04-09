using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;

namespace FormBuilder.Core.Domain.Models.Fields.Response
{
    public abstract class BaseFieldResponse : IValidable
    {
        public int Id { get; protected set; }
        public abstract ValidationResult Validate();
    }
}
