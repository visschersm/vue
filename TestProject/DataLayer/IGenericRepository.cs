using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TView>> GetAsync<TView>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TView>> select);
    }
}
