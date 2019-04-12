using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Application.AppService.Interfaces;
using FormBuilder.Core.Application.ViewModels.Forms.Builder;

namespace FormBuilder.Core.Application.AppService
{
    public class FormBuildQueryAppService : IFormBuildQueryAppService
    {
        private readonly DbContextCore _dbContext;
        public FormBuildQueryAppService(DbContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FormBuildVM>> ToListAsync()
        {
            IEnumerable<FormBuild> formBuilds = await _dbContext.FormBuilds.ToListAsync();
            return Mapper.Map<IEnumerable<FormBuildVM>>(formBuilds);
        }
    }
}
