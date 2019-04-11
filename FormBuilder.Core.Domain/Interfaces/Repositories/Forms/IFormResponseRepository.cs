using System.Threading.Tasks;
using FormBuilder.Core.Domain.Models.Forms.Response;

namespace FormBuilder.Core.Domain.Interfaces.Repositories.Forms
{
    public interface IFormResponseRepository
    {
        Task<FormResponse> FindAsync(int id);
        Task AddAsync(FormResponse formResponse);
        void Update(FormResponse formResponse);
        Task RemoveAsync(int id);
    }
}
