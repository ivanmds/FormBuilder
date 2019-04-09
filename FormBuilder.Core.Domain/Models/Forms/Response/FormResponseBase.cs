using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;
using FormBuilder.Core.Domain.Models.Forms.Builder;
using System.Collections.Generic;

namespace FormBuilder.Core.Domain.Models.Forms.Response
{
    public abstract class FormResponseBase : FormBase, IValidable
    {
        public abstract ValidationResult Validate();

        protected List<ValidationFailure> GetFieldsValidate()
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            if (Fields.Count > 0)
            {
                foreach (var field in Fields)
                {
                    ValidationResult result = field.Validate();
                    if (!result.IsValid)
                        failures.AddRange(result.Errors);
                }
            }

            return failures;
        }
    }
}
