using System;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Interfaces.Validation;
using FormBuilder.Core.Domain.Models.Fields;
using System.Collections.Generic;
using FormBuilder.Core.Domain.Validations.Forms;
using FormBuilder.Core.Domain.Models.Fields.Numbers;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public class FBuilder : IValidable
    {
        public FBuilder(string name, DateTime expiredIn)
        {
            Name = name;
            ExpiredIn = expiredIn;
        }

        public string Name { get; private set; }
        public DateTime ExpiredIn { get; private set; }
        public bool IsActive => ExpiredIn > DateTime.Now;

        private Dictionary<int, BaseField> _fields = new Dictionary<int, BaseField>();
        public IReadOnlyDictionary<int, BaseField> Fields => _fields;

        public bool AddField(int index, BaseField field)
        {
            if (_fields.ContainsKey(index)) return false;
            if (field == null) throw new NullReferenceException("field not null.");

            _fields.Add(index, field);
            return true;
        }

        public ValidationResult Validate()
        {
            ValidationResult fBuilderValidation = new FBuilderValidation().Validate(this);
            List<ValidationFailure> fieldValidations = GetFieldsValidate();

            if (!fBuilderValidation.IsValid)
                fieldValidations.AddRange(fBuilderValidation.Errors);

            return new ValidationResult(fieldValidations);
        }

        private List<ValidationFailure> GetFieldsValidate()
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
