using System.Threading.Tasks;

namespace FormBuilder.Core.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
