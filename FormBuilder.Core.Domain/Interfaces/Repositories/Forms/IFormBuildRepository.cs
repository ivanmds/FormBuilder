using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Repositories.Forms
{
    public interface IFormBuildRepository
    {
        Task<FormBuild> GetAsync(int id);
        Task AddAsync(FormBuild fBuilder);
        Task UpdateAsync(FormBuild fBuilder);
        Task DeleteAsync(int id);
    }
}
