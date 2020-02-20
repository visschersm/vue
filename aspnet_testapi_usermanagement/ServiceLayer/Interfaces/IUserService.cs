using DataLayer.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Users;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<Tuple<TView?, IEnumerable<IdentityError>>> CreateAsync<TView>(ViewModels.Users.Create createView)
            where TView : class, IViewOf<User>;

        Task<IEnumerable<TView>> CreateAsync<TView>(ViewModels.Users.Create[] createViews)
            where TView : IViewOf<User>;

        Task<TView> GetByIdAsync<TView>(Guid id)
            where TView : IViewOf<User>;
        Task<IEnumerable<TView>> GetByIdAsync<TView>(IEnumerable<Guid> ids)
            where TView : IViewOf<User>;

        Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<User, bool>>? filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes)
            where TView : IViewOf<User>;

        Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<User, TView>> select,
            Expression<Func<User, bool>>? filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes)
            where TView : IViewOf<User>;

        Task<TView> UpdateAsync<TView>(Guid id, IUpdateView<User> updateView)
            where TView : IViewOf<User>;

        Task<IEnumerable<TView>> UpdateAsync<TView>(ViewModels.Interfaces.IBatchUpdateView<User>[] updateViews)
            where TView : IViewOf<User>;

        Task<bool> DeleteAsync(Guid id);
        Task<TView> AuthenticateAsync<TView>(Authenticate model)
            where TView : IViewOf<User>;
    }
}
