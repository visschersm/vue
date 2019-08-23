using System;
using System.Linq.Expressions;

namespace DAL
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        TView GetAsync<TView>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TView>> selectExpression);
    }
}
