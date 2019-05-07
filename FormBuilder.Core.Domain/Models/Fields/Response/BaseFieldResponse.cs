using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;
using FormBuilder.Core.Domain.Models.Fields.Builder;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Shared.Kernel.Model;

namespace FormBuilder.Core.Domain.Models.Fields.Response
{
    public abstract class BaseFieldResponse : EntityBase, IValidable
    {
        public FormResponse FormResponse { get; protected set; }
        public BaseFieldBuilder FieldBuild { get; protected set; }
        public abstract ValidationResult Validate();
    }
}
