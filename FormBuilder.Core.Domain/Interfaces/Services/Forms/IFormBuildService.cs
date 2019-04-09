using FormBuilder.Core.Domain.Models.Forms;
using System.Threading.Tasks;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFormBuildService
    {
        Task<FormBuild> FindAsync(int id);
        Task AddAsync(FormBuild fBuilder);
        void Update(FormBuild fBuilder);
        Task RemoveAsync(int id);
    }
}
