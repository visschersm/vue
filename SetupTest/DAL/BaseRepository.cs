using System;
using System.Linq.Expressions;

namespace DAL
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public TView GetAsync<TView>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TView>> selectExpression)
        {
            throw new NotImplementedException();
        }
    }
}
