using FluentValidation.Results;
using FormBuilder.Core.Domain.Models.Numbers;
using Xunit;

namespace FormBuilder.Core.Domain.Test.Models
{
    public class IntFieldTest
    {
        [Fact]
        public void IntField_Success()
        {
            //arrange
            IntField intField = new IntField("idade", 10, 20, false);
            intField.SetValue(12);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.True(result.IsValid, "Regras não estão ok.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void IntField_IsRequiresTrue_ResultTrue(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", isRequired: true);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.True(result.IsValid, "Regras do isRequired não estão ok.");
        }

        [Fact]
        public void IntField_IsRequiresTrue_ResultFalse()
        {
            //arrange
            IntField intField = new IntField("value_test", isRequired: true);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.False(result.IsValid, "Regras do IsRequires não estão ok.");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(int.MaxValue)]
        [InlineData(123456789)]
        public void IntField_MinValue_ResultTrue(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", minValue: 2);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.True(result.IsValid, "Regras do MinValue não estão ok.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        public void IntField_MinValue_ResultFalse(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", minValue: 2);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.False(result.IsValid, "Regras do MinValue não estão ok.");
        }

        [Theory]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(0)]
        public void IntField_MaxValue_ResultTrue(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", maxValue: 10);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.True(result.IsValid, "Regras do MinValue não estão ok.");
        }

        [Theory]
        [InlineData(11)]
        [InlineData(int.MaxValue)]
        [InlineData(20)]
        public void IntField_MaxValue_ResultFalse(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", maxValue: 10);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.False(result.IsValid, "Regras do MinValue não estão ok.");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void TextField_CreateNewField_ResultTrue(int value)
        {
            //arrange
            IntField intField = new IntField("value_test", 5, 10, true);
            intField.SetValue(value);

            //act
            ValidationResult result = intField.IsValid();

            //assert
            Assert.True(result.IsValid, "Regras do MinValue não estão ok.");
        }
    }
}
