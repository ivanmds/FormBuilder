using Xunit;
using System;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Data.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using System.Threading.Tasks;
using FormBuilder.Core.Data.UnitOfWorks;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Domain.Models.Fields.Builder.Numbers;
using FormBuilder.Core.Domain.Models.Fields.Builder.Texts;

namespace FormBuilder.Core.Data.Test.Repositories.Form
{
    public class FormBuildRepositoryTest : IDisposable
    {
        private readonly IFormBuildRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextCore _dbContext;

        public FormBuildRepositoryTest()
        {
            _dbContext = new DbContextCore();
            _repository = new FormBuildRepository(_dbContext);
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        [Fact]
        public async Task FormBuildRepository_AddNewForm_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));

            //act
            await _repository.AddAsync(formBuild);
            await _unitOfWork.SaveChangesAsync();

            //assert
            Assert.True(formBuild.Id > 0);
        }

        [Fact]
        public async Task FormBuildRepository_FindFormById_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));
            await _repository.AddAsync(formBuild);
            await _unitOfWork.SaveChangesAsync();

            //act
            FormBuild formBuildFind = await _dbContext.FormBuilds.FindAsync(formBuild.Id);

            //assert
            Assert.NotNull(formBuildFind);
        }

        [Fact]
        public async Task FormBuildRepository_UpdateForm_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));
            await _repository.AddAsync(formBuild);
            await _unitOfWork.SaveChangesAsync();
            formBuild.SetName("Test 2");

            //act
            _repository.Update(formBuild);
            await _unitOfWork.SaveChangesAsync();
            FormBuild formUpdated = await _dbContext.FormBuilds.FindAsync(formBuild.Id);

            //assert
            Assert.Equal(formUpdated.Id, formBuild.Id);
            Assert.Equal(formUpdated.Name, formBuild.Name);
        }

        [Fact]
        public async Task FormBuildRepository_RemoveFormBuildById_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));
            await _repository.AddAsync(formBuild);
            await _unitOfWork.SaveChangesAsync();

            //act
            await _repository.RemoveAsync(formBuild.Id);
            await _unitOfWork.SaveChangesAsync();
            FormBuild formRemoved = await _dbContext.FormBuilds.FindAsync(formBuild.Id);

            //assert
            Assert.Null(formRemoved);
        }

        [Fact]
        public async Task FormBuildRepository_AddOneFields_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            formBuild.AddField(intField);
            await _repository.AddAsync(formBuild);

            //act
            await _unitOfWork.SaveChangesAsync();
            FormBuild formSaved = await _dbContext.FormBuilds.FindAsync(formBuild.Id);

            //assert
            Assert.NotNull(formSaved);
            Assert.True(formSaved.Fields.Count == 1);
        }

        [Fact]
        public async Task FormBuildRepository_AddTwoFields_Success()
        {
            //arrange
            FormBuild formBuild = new FormBuild("Test", DateTime.Now.AddDays(10));
            IntFieldBuilder intField = new IntFieldBuilder("value_test", 5, 10, true);
            TextFieldBuilder textField = new TextFieldBuilder("name", 10, 20, true, "Your name");
            formBuild.AddField(intField);
            formBuild.AddField(textField);
            await _repository.AddAsync(formBuild);

            //act
            await _unitOfWork.SaveChangesAsync();
            FormBuild formSaved = await _dbContext.FormBuilds.FindAsync(formBuild.Id);

            //assert
            Assert.NotNull(formSaved);
            Assert.True(formSaved.Fields.Count == 2);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
