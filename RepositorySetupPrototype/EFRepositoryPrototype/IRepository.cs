using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFRepositoryPrototype
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);

        Task<TEntity[]> GetAsync();
    }
}
