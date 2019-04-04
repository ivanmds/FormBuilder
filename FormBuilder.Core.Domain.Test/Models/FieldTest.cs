using FormBuilder.Core.Domain.Models;
using Xunit;

namespace FormBuilder.Core.Domain.Test.Models
{
    public class FieldTest
    {

        [Fact]
        public void FieldTest_NewTextField_Success()
        {
            //arrange
            TextField tField = new TextField("Name", 20, 5, false);
            tField.SetValue("Testing field");

            //act
            bool tFieldIsValid = tField.IsValid();

            //assert
            Assert.True(tFieldIsValid, "Campo texto não é válido.");
        }
    }
}
