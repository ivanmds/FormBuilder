using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Fields.Numbers;
using FormBuilder.Core.Domain.Models.Forms;
using System;
using Xunit;

namespace FormBuilder.Core.Domain.Test.Models.Forms
{
    public class FBuilderTest
    {
        [Fact]
        public void FormBuilder_Success()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);

            //act
            ValidationResult result = fBuilder.Validate();

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormBuilder_AddFiledInvalid_ResultFalse()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);
            
            IntField intField = new IntField("value_test", 5, 10, true);
            //set value invalid
            intField.SetValue(11);

            fBuilder.AddField(1, intField);

            //act
            ValidationResult result = fBuilder.Validate();


            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }
    }
}
