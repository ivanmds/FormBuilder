using Xunit;
using System;
using NSubstitute;
using System.Threading.Tasks;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Services.Forms;
using FormBuilder.Core.Domain.Models.Fields.Texts;
using FormBuilder.Core.Domain.Models.Fields.Numbers;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;

namespace FormBuilder.Core.Domain.Test.Models.Services
{
    public class FormResponseServiceTest
    {
        private FormResponseService _service;
        private IFormResponseRepository _repository;

        public FormResponseServiceTest()
        {
            _repository = Substitute.For<IFormResponseRepository>();
            _service = new FormResponseService(_repository);
        }

        [Fact]
        public async Task FormResponseService_AddFormResponseValid_ResultValid()
        {
            //arrange
            FormResponse formResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            intField.SetValue(10);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            formResponse.AddField(intField);
            formResponse.AddField(textField);
            
            await _repository.AddAsync(formResponse);

            //act
            ValidationResult result = await _service.AddAsync(formResponse);

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public async Task FormResponseService_AddFormResponseInvalid_ResultInvalid()
        {
            //arrange
            FormResponse formResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            intField.SetValue(11);

            TextField textField = new TextField("text", isRequired: true);

            formResponse.AddField(intField);
            formResponse.AddField(textField);

            //add form invalid
            await _repository.AddAsync(formResponse);

            //act
            ValidationResult result = await _service.AddAsync(formResponse);

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public async Task FormResponseService_UpdateFormResponseValid_ResultValid()
        {
            //arrange
            FormResponse formResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            intField.SetValue(10);

            TextField textField = new TextField("text");
            textField.SetValue("valid");

            formResponse.AddField(intField);
            formResponse.AddField(textField);

            await _repository.UpdateAsync(formResponse);

            //act
            ValidationResult result = await _service.UpdateAsync(formResponse);

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public async Task FormResponseService_UpdateFormResponseInvalid_ResultInvalid()
        {
            //arrange
            FormResponse formResponse = new FormResponse("Teste", DateTime.Now);

            IntField intField = new IntField("value_test", 5, 10, true);
            intField.SetValue(11);

            TextField textField = new TextField("text", isRequired: true);

            formResponse.AddField(intField);
            formResponse.AddField(textField);

            //add form invalid
            await _repository.UpdateAsync(formResponse);

            //act
            ValidationResult result = await _service.UpdateAsync(formResponse);

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }
    }
}
