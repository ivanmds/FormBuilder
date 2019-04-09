﻿using Xunit;
using System;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Models.Fields.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Texts;

namespace Form.Core.Domain.Test.Models.Forms
{
    public class FormResponseTest
    {
        [Fact]
        public void FormResponse_Success()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);

            //act
            ValidationResult result = FormResponse.Validate();

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponse_AddFiledInvalid_ResultFalse()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            
            IntField intField = new IntField("value_test", 5, 10, true);
            //set value invalid
            intField.SetValue(11);

            FormResponse.AddField(intField);

            //act
            ValidationResult result = FormResponse.Validate();

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }


        [Fact]
        public void FormResponse_AddNewIndex_ResultTrue()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");

            //act
            bool indexAdd = FormResponse.AddField(textField);

            //assert
            Assert.True(indexAdd);
        }
    }
}