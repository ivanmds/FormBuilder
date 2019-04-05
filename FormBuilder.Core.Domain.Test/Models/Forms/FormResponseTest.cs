using Xunit;
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

            FormResponse.AddField(1, intField);

            //act
            ValidationResult result = FormResponse.Validate();

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponse_AddFiledValidAndInvalid_ResultFalse()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            //set value invalid
            intField.SetValue(11);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            FormResponse.AddField(1, intField);
            FormResponse.AddField(1, textField);

            //act
            ValidationResult result = FormResponse.Validate();

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponse_AddFiledsValid_ResultTrue()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            //set value valid
            intField.SetValue(10);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            FormResponse.AddField(1, intField);
            FormResponse.AddField(1, textField);

            //act
            ValidationResult result = FormResponse.Validate();

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponse_AddNewIndex_ResultTrue()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");

            //act
            bool indexAdd = FormResponse.AddField(1, textField);

            //assert
            Assert.True(indexAdd);
        }

        [Fact]
        public void FormResponse_AddIndexAlreadyExisting_ResultFalse()
        {
            //arrange
            int index = 1;
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");
            FormResponse.AddField(index, textField);

            //act
            bool indexAdd = FormResponse.AddField(index, textField);

            //assert
            Assert.False(indexAdd);
        }

        [Fact]
        public void FormResponse_IndexEqualZeroOrLowerZero_ThrowArgumentException()
        {
            //arrange
            int index = 0;
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");

            //act and assert
            Assert.Throws<ArgumentException>(() => FormResponse.AddField(index, textField));
        }

        [Fact]
        public void FormResponse_FieldEqualNull_ThrowArgumentException()
        {
            //arrange
            FormResponse FormResponse = new FormResponse("Teste", DateTime.Now);
            TextField textField = null;

            //act and assert
            Assert.Throws<ArgumentException>(() => FormResponse.AddField(1, textField));
        }
    }
}
