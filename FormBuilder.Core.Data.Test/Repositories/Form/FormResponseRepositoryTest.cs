using Xunit;
using System;
using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Forms.Response;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Data.UnitOfWorks;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Data.Repositories.Forms;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Response.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;
using FormBuilder.Core.Domain.Models.Fields.Response.Texts;
using System.Linq;

namespace FormBuilder.Core.Data.Test.Repositories.Form
{
    public class FormResponseRepositoryTest : IDisposable
    {
        private readonly DbContextCore _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFormResponseRepository _repository;

        public FormResponseRepositoryTest()
        {
            _dbContext = new DbContextCore();
            _repository = new FormResponseRepository(_dbContext);
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        [Fact]
        public async Task FormResponseRepository_AddNew_Success()
        {
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            FormResponse formResponse = new FormResponse(formBuild);

            //act
            await _repository.AddAsync(formResponse);
            await _unitOfWork.SaveChangesAsync();

            //assert
            Assert.True(formResponse.Id > 0);
        }

        [Fact]
        public async Task FormResponseRepository_RespondForm_Success()
        {
            //arrange
            IFormBuildRepository buildRepository = new FormBuildRepository(_dbContext);
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(intField);
            await buildRepository.AddAsync(formBuild);
            await _unitOfWork.SaveChangesAsync();

            FormResponse formResponse = new FormResponse(formBuild);
            IntFieldResponse intFieldResponse = new IntFieldResponse(intField);
            intFieldResponse.SetValue(10);
            formResponse.AddField(intFieldResponse);

            //act
            await _repository.AddAsync(formResponse);
            await _unitOfWork.SaveChangesAsync();

            //assert
            Assert.True(intFieldResponse.Id > 0);
        }

        [Fact]
        public async Task FormResponseRepository_RespondFormMultiplesFields_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("age", 5, 10, true);
            TextFieldBuilder textField = new TextFieldBuilder("name");

            formBuild.AddField(intField);
            formBuild.AddField(textField);
            
            FormResponse formResponse = new FormResponse(formBuild);

            IntFieldResponse intFieldResponse = new IntFieldResponse(intField);
            intFieldResponse.SetValue(10);
            formResponse.AddField(intFieldResponse);

            TextFieldResponse textFieldResponse = new TextFieldResponse(textField);
            textFieldResponse.SetValue("Maria");
            formResponse.AddField(textFieldResponse);

            //act
            await _repository.AddAsync(formResponse);
            await _unitOfWork.SaveChangesAsync();

            //assert
            Assert.True(intFieldResponse.Id > 0);
        }

        [Fact]
        public async Task FormResponseRepository_UpdateValueResponse_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);
            IntFieldResponse intFieldResponse = new IntFieldResponse(intField);
            intFieldResponse.SetValue(10);
            formResponse.AddField(intFieldResponse);

            await _repository.AddAsync(formResponse);
            await _unitOfWork.SaveChangesAsync();
            int setNewValue = 5;

            //act
            FormResponse formResponseFound = await _repository.FindAsync(formResponse.Id);
            IntFieldResponse intFieldResponseFound = null;
            if (formResponseFound != null && formResponseFound.Fields?.Count > 0)
            {
                intFieldResponseFound = formResponseFound.Fields.First() as IntFieldResponse;
                intFieldResponseFound.SetValue(setNewValue);
                await _unitOfWork.SaveChangesAsync();

                formResponseFound = await _repository.FindAsync(formResponse.Id);
                intFieldResponseFound = formResponseFound.Fields.First() as IntFieldResponse;
            }

            //assert
            Assert.NotNull(formResponseFound);
            Assert.True(formResponseFound.Fields?.Count == formResponse.Fields?.Count);
            Assert.True(intFieldResponseFound.Value == setNewValue);
        }

        [Fact]
        public async Task FormResponseRepository_DeleteFormResponse_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Teste", DateTime.Now);
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(intField);

            FormResponse formResponse = new FormResponse(formBuild);
            IntFieldResponse intFieldResponse = new IntFieldResponse(intField);
            intFieldResponse.SetValue(10);
            formResponse.AddField(intFieldResponse);

            await _repository.AddAsync(formResponse);
            await _unitOfWork.SaveChangesAsync();
            int formResponseId = formResponse.Id;

            //act
            await _repository.RemoveAsync(formResponseId);
            await _unitOfWork.SaveChangesAsync();

            FormResponse formResponseNotFound = await _repository.FindAsync(formResponseId);

            //assert
            Assert.Null(formResponseNotFound);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
