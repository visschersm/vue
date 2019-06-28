using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TView[] Add<TView>(params TEntity[] entities)
            where TView : IViewOf<TEntity>;
        Task<TView[]> AddAsync<TView>(params TEntity[] entities)
            where TView : IViewOf<TEntity>;

        TView[] Get<TView>(
            Expression<Func<TEntity, bool>> filterExpression = null,
            Expression<Func<TEntity, TView>> selectExpression = null
            /*Expression<Func<TProperty>> includes*/)
            where TView : IViewOf<TEntity>;
        Task<TView[]> GetAsync<TView>(
            Expression<Func<TEntity, bool>> filterExpression = null,
            Expression<Func<TEntity, TView>> selectExpression = null)
            where TView : IViewOf<TEntity>;

        TView[] Update<TView>(
            Expression<Func<TEntity, TView>> selectExpression,
            params TEntity[] entities)
            where TView : IViewOf<TEntity>;
        Task<TView[]> UpdateAsync<TView>(
            Expression<Func<TEntity, TView>> selectExpression,
            params TEntity[] entities)
            where TView : IViewOf<TEntity>;

        void Delete(params TEntity[] entities);
        Task DeleteAsync(params TEntity[] entities);
    }
}
