using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFormBuildService
    {
        Task AddAsync(FormBuild fBuilder);
        void Update(FormBuild fBuilder);
        Task RemoveAsync(int id);
    }
}
