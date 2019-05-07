using System.Threading.Tasks;
using FormBuilder.Shared.Kernel.Pagination;
using FormBuilder.Core.Application.ViewModels.Forms.Builder;

namespace FormBuilder.Core.Application.AppService.Interfaces
{
    public interface IFormBuildQueryAppService
    {
        Task<Page<FormBuildVM>> PaginateAsync(PageFilter pageInfo);
    }
}
