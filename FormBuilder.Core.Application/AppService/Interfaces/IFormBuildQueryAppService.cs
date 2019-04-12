using System.Threading.Tasks;
using System.Collections.Generic;
using FormBuilder.Core.Application.ViewModels.Forms.Builder;

namespace FormBuilder.Core.Application.AppService.Interfaces
{
    public interface IFormBuildQueryAppService
    {
        Task<IEnumerable<FormBuildVM>> ToListAsync();
    }
}
