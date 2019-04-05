using Xunit;
using System;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Fields.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Texts;
using FormBuilder.Core.Domain.Models.Forms;

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

        [Fact]
        public void FormBuilder_AddFiledValidAndInvalid_ResultFalse()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            //set value invalid
            intField.SetValue(11);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            fBuilder.AddField(1, intField);
            fBuilder.AddField(1, textField);

            //act
            ValidationResult result = fBuilder.Validate();

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormBuilder_AddFiledsValid_ResultTrue()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            //set value valid
            intField.SetValue(10);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            fBuilder.AddField(1, intField);
            fBuilder.AddField(1, textField);

            //act
            ValidationResult result = fBuilder.Validate();

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormBuilder_AddNewIndex_ResultTrue()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");

            //act
            bool indexAdd = fBuilder.AddField(1, textField);

            //assert
            Assert.True(indexAdd);
        }

        [Fact]
        public void FormBuilder_AddIndexAlreadyExisting_ResultFalse()
        {
            //arrange
            int index = 1;
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");
            fBuilder.AddField(index, textField);

            //act
            bool indexAdd = fBuilder.AddField(index, textField);

            //assert
            Assert.False(indexAdd);
        }

        [Fact]
        public void FormBuilder_IndexEqualZeroOrLowerZero_ThrowArgumentException()
        {
            //arrange
            int index = 0;
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);
            TextField textField = new TextField("text");
            textField.SetValue("valid");

            //act and assert
            Assert.Throws<ArgumentException>(() => fBuilder.AddField(index, textField));
        }

        [Fact]
        public void FormBuilder_FieldEqualNull_ThrowArgumentException()
        {
            //arrange
            FBuilder fBuilder = new FBuilder("Teste", DateTime.Now);
            TextField textField = null;

            //act and assert
            Assert.Throws<ArgumentException>(() => fBuilder.AddField(1, textField));
        }
    }
}
