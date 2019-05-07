using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Application.AppService.Interfaces;
using FormBuilder.Core.Application.ViewModels.Forms.Builder;
using FormBuilder.Shared.Kernel.Pagination;
using System.Linq;

namespace FormBuilder.Core.Application.AppService
{
    public class FormBuildQueryAppService : IFormBuildQueryAppService
    {
        private readonly DbContextCore _dbContext;
        public FormBuildQueryAppService(DbContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Page<FormBuildVM>> PaginateAsync(PageFilter pageInfo)
        {
            int skip = pageInfo.Size * (pageInfo.Number - 1);

            int total = await _dbContext.FormBuilds.CountAsync();
            var forms = await _dbContext.FormBuilds.Skip(skip).Take(pageInfo.Size).ToListAsync();

            var formsVM = Mapper.Map<IEnumerable<FormBuildVM>>(forms);

            return new Page<FormBuildVM>(formsVM, total);
        }
    }
}
