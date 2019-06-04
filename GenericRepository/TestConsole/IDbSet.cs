using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestConsole
{
    public interface IDbSet<TEntity>
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        IEnumerable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> filterExpression) where TEntity : class;
        TEntity Find(object id);
        IEnumerable<TEntity> ToArray();
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}
