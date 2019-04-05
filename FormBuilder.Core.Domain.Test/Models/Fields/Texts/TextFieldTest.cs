using Xunit;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Fields.Texts;

namespace FormBuilder.Core.Domain.Test.Models.Fields.Texts
{
    public class TextFieldTest
    {

        [Fact]
        public void TextField_Success()
        {
            //arrange
            TextField tField = new TextField("Name", 5, 20, false);
            tField.SetValue("Testing field");

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("t")]
        [InlineData("t 1")]
        [InlineData("t 1 2345679")]
        public void TextField_IsRequired_ResultTrue(string value)
        {
            //arrange
            TextField tField = new TextField("nome", isRequired: true);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void TextField_IsRequired_ResultFalse(string value)
        {
            //arrange
            TextField tField = new TextField("nome", isRequired: true);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.False(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123456")]
        [InlineData("123456789")]
        public void TextField_MinLenght_ResultTrue(string value)
        {
            //arrange
            TextField tField = new TextField("nome", minLength: 3);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("12")]
        [InlineData("1")]
        [InlineData("")]
        public void TextField_MinLenght_ResultFalse(string value)
        {
            //arrange
            TextField tField = new TextField("nome", minLength: 3);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.False(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123456")]
        [InlineData("123456789")]
        public void TextField_MaxLenght_ResultTrue(string value)
        {
            //arrange
            TextField tField = new TextField("nome", maxLength: 10);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData("12345678910")]
        [InlineData("1234567891011")]
        [InlineData("123456789101112")]
        public void TextField_MaxLenght_ResultFalse(string value)
        {
            //arrange
            TextField tField = new TextField("nome", maxLength: 10);
            tField.SetValue(value);

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.False(result.IsValid, "Regras não estão ok.");
        }

        [Fact]
        public void TextField_CreateNewField_ResultTrue()
        {
            //arrange
            TextField tField = new TextField("nome", 5, 10, true);
            tField.SetValue("teste");

            //act
            ValidationResult result = tField.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }
    }
}
