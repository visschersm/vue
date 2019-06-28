using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public TView[] Add<TView>(params TEntity[] entities)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView[]> AddAsync<TView>(params TEntity[] entities)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public TView[] Get<TView>(
            Expression<Func<TEntity, bool>> filterExpression = null,
            Expression<Func<TEntity, TView>> selectExpression = null)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView[]> GetAsync<TView>(
            Expression<Func<TEntity, bool>> filterExpression = null,
            Expression<Func<TEntity, TView>> selectExpression = null)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public TView[] Update<TView>(
            Expression<Func<TEntity, TView>> selectExpression,
            params TEntity[] entities)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView[]> UpdateAsync<TView>(
            Expression<Func<TEntity, TView>> selectExpression,
            params TEntity[] entities)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
