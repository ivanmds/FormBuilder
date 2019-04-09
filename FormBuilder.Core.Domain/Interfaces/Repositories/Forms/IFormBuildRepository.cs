using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Repositories.Forms
{
    public interface IFormBuildRepository
    {
        Task<FormBuild> FindAsync(int id);
        Task AddAsync(FormBuild fBuilder);
        void Update(FormBuild fBuilder);
        Task RemoveAsync(int id);
    }
}
