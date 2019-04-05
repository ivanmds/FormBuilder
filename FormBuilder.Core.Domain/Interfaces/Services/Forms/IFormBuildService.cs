using FormBuilder.Core.Domain.Models.Forms;
using System.Threading.Tasks;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFormBuildService
    {
        Task<FormBuild> GetAsync(int id);
        Task AddAsync(FormBuild fBuilder);
        Task UpdateAsync(FormBuild fBuilder);
        Task DeleteAsync(int id);
    }
}
