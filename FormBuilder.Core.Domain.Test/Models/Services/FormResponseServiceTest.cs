using Xunit;
using System;
using NSubstitute;
using System.Threading.Tasks;
using FluentValidation.Results;
using FormBuilder.Core.Domain.Services.Forms;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;

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
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            TextFieldBuilder textField = new TextFieldBuilder("text");
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(textField);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);

            TextFieldResponse textResponse = new TextFieldResponse(textField);
            textResponse.SetValue("valid");

            IntFieldResponse intResponse = new IntFieldResponse(intField);
            intResponse.SetValue(10);

            formResponse.AddField(textResponse);
            formResponse.AddField(intResponse);

            //act
            ValidationResult result = await _service.AddAsync(formResponse);

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public async Task FormResponseService_AddFormResponseInvalid_ResultInvalid()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            TextFieldBuilder textField = new TextFieldBuilder("text", isRequired: true);
            formBuild.AddField(textField);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);

            IntFieldResponse intResponse = new IntFieldResponse(intField);
            intResponse.SetValue(11);

            TextFieldResponse textResponse = new TextFieldResponse(textField);
           
            formResponse.AddField(intResponse);
            formResponse.AddField(textResponse);

            //act
            ValidationResult result = await _service.AddAsync(formResponse);

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponseService_UpdateFormResponseValid_ResultValid()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            TextFieldBuilder textField = new TextFieldBuilder("text");
            formBuild.AddField(textField);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);

            IntFieldResponse intResponse = new IntFieldResponse(intField);
            intResponse.SetValue(10);

            TextFieldResponse textResponse = new TextFieldResponse(textField);
            textResponse.SetValue("valid");

            formResponse.AddField(intResponse);
            formResponse.AddField(textResponse);

            _repository.Update(formResponse);

            //act
            ValidationResult result = _service.Update(formResponse);

            //assert
            Assert.True(result.IsValid, "Formulário não está válido");
        }

        [Fact]
        public void FormResponseService_UpdateFormResponseInvalid_ResultInvalid()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            TextFieldBuilder textField = new TextFieldBuilder("text", isRequired: true);
            formBuild.AddField(textField);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);

            TextFieldResponse textResponse = new TextFieldResponse(textField);
            IntFieldResponse intResponse = new IntFieldResponse(intField);
            intResponse.SetValue(11);

            formResponse.AddField(intResponse);
            formResponse.AddField(textResponse);

            //add form invalid
            _repository.Update(formResponse);

            //act
            ValidationResult result = _service.Update(formResponse);

            //assert
            Assert.False(result.IsValid, "Formulário não está válido");
        }
    }
}
