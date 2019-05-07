using FormBuilder.Shared.Kernel.Model;
using System.Collections.Generic;

namespace FormBuilder.Shared.Kernel.Pagination
{
    public class Page<TEntity> where TEntity : EntityBase
    {
        public Page(IEnumerable<TEntity> data, int total)
        {
            Data = data;
            Total = total;
        }

        public IEnumerable<TEntity> Data { get; protected set; }
        public int Total { get; protected set; }
    }
}
