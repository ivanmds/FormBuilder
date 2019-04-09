using Xunit;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;

namespace FormBuilder.Core.Domain.Test.Models.Fields.Texts
{
    public class TextFieldTest
    {
        [Fact]
        public void TextField_Success()
        {
            //arrange
            TextFieldBuilder tField = new TextFieldBuilder("Name", 5, 20, false);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue("Testing field");

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", isRequired: true);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", isRequired: true);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", minLength: 3);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", minLength: 3);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", maxLength: 10);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

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
            TextFieldBuilder tField = new TextFieldBuilder("nome", maxLength: 10);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue(value);

            //act
            ValidationResult result = fieldResponse.Validate();

            //assert
            Assert.False(result.IsValid, "Regras não estão ok.");
        }

        [Fact]
        public void TextField_CreateNewField_ResultTrue()
        {
            //arrange
            TextFieldBuilder tField = new TextFieldBuilder("nome", 5, 10, true);
            TextFieldResponse fieldResponse = new TextFieldResponse(tField);
            fieldResponse.SetValue("teste");

            //act
            ValidationResult result = fieldResponse.Validate();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }
    }
}
