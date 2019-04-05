using System;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;
using FormBuilder.Core.Domain.Models.Fields;
using System.Collections.Generic;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public abstract class FBuilderBase : IValidable
    {
        private Dictionary<int, BaseField> _fields = new Dictionary<int, BaseField>();
        public IReadOnlyDictionary<int, BaseField> Fields => _fields;

        public bool AddField(int index, BaseField field)
        {
            if (_fields.ContainsKey(index)) return false;
            if (field == null) throw new NullReferenceException("field not null.");

            _fields.Add(index, field);
            return true;
        }
        public abstract ValidationResult Validate();

        protected List<ValidationFailure> GetFieldsValidate()
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            if (Fields.Count > 0)
            {
                foreach (var keyValue in Fields)
                {
                    ValidationResult result = keyValue.Value.Validate();
                    if (!result.IsValid)
                        failures.AddRange(result.Errors);
                }
            }

            return failures;
        }
    }
}
