using DataLayer.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;

// Implementing the Repository and Unit of Work Patterns in ASP.NET MVC Application
// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application#implement-a-generic-repository-and-a-unit-of-work-class

namespace ServiceLayer.Interfaces
{
    public interface IGenericService<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        Task<TView> CreateAsync<TCreate, TView>(TCreate createView)
            where TCreate : ICreateView<TEntity>
            where TView : IViewOf<TEntity>;
        Task<IEnumerable<TView>> CreateAsync<TCreate, TView>(TCreate[] createViews)
            where TCreate : ICreateView<TEntity>
            where TView : IViewOf<TEntity>;

        Task<TView> GetByIdAsync<TView>(TKey id)
            where TView : IViewOf<TEntity>;
        Task<IEnumerable<TView>> GetByIdAsync<TView>(IEnumerable<TKey> ids)
            where TView : IViewOf<TEntity>;

        Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>> orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes)
            where TView : IViewOf<TEntity>;

        Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<TEntity, TView>> select,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>> orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes)
            where TView : IViewOf<TEntity>;

        Task<TView> UpdateAsync<TUpdate, TView>(TKey id, TUpdate updateView)
            where TUpdate : IUpdateView<TEntity>
            where TView : IViewOf<TEntity>;
        Task<IEnumerable<TView>> UpdateAsync<TUpdate, TView>(TUpdate[] updateViews)
            where TUpdate : IBatchUpdateView<TEntity>
            where TView : IViewOf<TEntity>;

        Task DeleteAsync(TKey id);
    }
}
