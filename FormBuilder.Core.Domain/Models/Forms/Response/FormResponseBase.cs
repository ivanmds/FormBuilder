using FluentValidation.Results;
using System.Collections.Generic;
using FormBuilder.Core.Domain.Interfaces.Validation;
using FormBuilder.Core.Domain.Models.Fields.Response;

namespace FormBuilder.Core.Domain.Models.Forms.Response
{
    public abstract class FormResponseBase :  IValidable
    {
        public int Id { get; protected set; }

        private List<BaseFieldResponse> _fields = new List<BaseFieldResponse>();
        public IReadOnlyCollection<BaseFieldResponse> Fields => _fields;

        public bool AddField(BaseFieldResponse field)
        {
            _fields.Add(field);
            return true;
        }

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
