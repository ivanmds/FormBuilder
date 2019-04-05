using System;
using FluentValidation.Results;
using System.Collections.Generic;
using FormBuilder.Core.Domain.Validations.Forms;

namespace FormBuilder.Core.Domain.Models.Forms.Response
{
    public class FormResponse : FormResponseBase
    {
        public FormResponse(string name, DateTime expiredIn)
        {
            Name = name;
            ExpiredIn = expiredIn;
        }

        public override ValidationResult Validate()
        {
            ValidationResult fBuilderValidation = new FormBaseValidation().Validate(this);
            List<ValidationFailure> fieldValidations = GetFieldsValidate();

            if (!fBuilderValidation.IsValid)
                fieldValidations.AddRange(fBuilderValidation.Errors);

            return new ValidationResult(fieldValidations);
        }
    }
}
