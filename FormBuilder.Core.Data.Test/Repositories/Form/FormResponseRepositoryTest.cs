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

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
