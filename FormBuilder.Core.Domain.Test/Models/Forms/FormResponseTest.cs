using Xunit;
using System;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Forms;

namespace Form.Core.Domain.Test.Models.Forms
{
    public class FormResponseTest
    {
        [Fact]
        public void FormResponse_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            FormResponse formResponse = new FormResponse(formBuild);

            //act
            ValidationResult result = formResponse.Validate();

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponse_AddFiledInvalid_ResultFalse()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);
            IntFieldResponse intFieldResponse = new IntFieldResponse(intField);
            //set value invalid
            intFieldResponse.SetValue(11);

            formResponse.AddField(intFieldResponse);

            //act
            ValidationResult result = formResponse.Validate();

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }


        [Fact]
        public void FormResponse_AddNewIndex_ResultTrue()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            TextFieldBuilder textField = new TextFieldBuilder("text");
            formBuild.AddField(textField);

            FormResponse formResponse = new FormResponse(formBuild);
            TextFieldResponse textFieldResponse = new TextFieldResponse(textField);
            textFieldResponse.SetValue("valid");

            //act
            bool indexAdd = formResponse.AddField(textFieldResponse);

            //assert
            Assert.True(indexAdd);
        }
    }
}
