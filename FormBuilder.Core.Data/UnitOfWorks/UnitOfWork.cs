using System.Threading.Tasks;
using FormBuilder.Core.Data.DbContexts;

namespace FormBuilder.Core.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContextCore _dbContext;
        public UnitOfWork(DbContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
