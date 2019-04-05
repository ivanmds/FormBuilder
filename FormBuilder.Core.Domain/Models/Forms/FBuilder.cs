using System;
using FluentValidation.Results;
using System.Collections.Generic;
using FormBuilder.Core.Domain.Validations.Forms;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public class FBuilder : FBuilderBase
    {
        public FBuilder(string name, DateTime expiredIn)
        {
            Name = name;
            ExpiredIn = expiredIn;
        }

        public string Name { get; private set; }
        public DateTime ExpiredIn { get; private set; }
        public bool IsActive => ExpiredIn > DateTime.Now;

        public override ValidationResult Validate()
        {
            ValidationResult fBuilderValidation = new FBuilderValidation().Validate(this);
            List<ValidationFailure> fieldValidations = GetFieldsValidate();

            if (!fBuilderValidation.IsValid)
                fieldValidations.AddRange(fBuilderValidation.Errors);

            return new ValidationResult(fieldValidations);
        }
    }
}
