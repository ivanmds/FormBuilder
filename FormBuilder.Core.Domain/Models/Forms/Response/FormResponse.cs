using FluentValidation.Results;
using System.Collections.Generic;

namespace FormBuilder.Core.Domain.Models.Forms.Response
{
    public class FormResponse : FormResponseBase
    {
        //ef
        protected FormResponse() { }

        public FormResponse(FormBuild formBuild)
        {
            FormBuild = formBuild;
        }

        public FormBuild FormBuild { get; protected set; }

        public override ValidationResult Validate()
        {
            List<ValidationFailure> fieldValidations = GetFieldsValidate();
            return new ValidationResult(fieldValidations);
        }
    }
}
