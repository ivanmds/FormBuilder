﻿using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Validations.Fields.Numbers;

namespace FormBuilder.Core.Domain.Models.Fields.Response.Numbers
{
    public class IntFieldResponse : FieldTypeResponse<IntFieldBuilder, int?>
    {
        public IntFieldResponse(IntFieldBuilder field)
        {
            Field = field;
        }

        public override ValidationResult Validate()
        {
            return new IntFieldValidation().Validate(this);
        }
    }
}
