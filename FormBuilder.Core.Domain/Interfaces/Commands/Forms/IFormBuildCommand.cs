using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Commands.Forms
{
    public interface IFormBuildCommand
    {
        Task AddAsync(FormBuild fBuilder);
        void Update(FormBuild fBuilder);
        Task RemoveAsync(int id);
    }
}
