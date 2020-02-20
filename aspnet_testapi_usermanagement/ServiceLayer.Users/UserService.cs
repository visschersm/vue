using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using DataLayer.Entities.Entities;
using DataLayer.Entities.Interfaces;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Users;

namespace ServiceLayer.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IDataContext _context;
        private readonly DbSet<User> _repository;

        public UserService(ApplicationUserManager userManager, IDataContext context, IMapper mapper)
        {
            ApplicationDbContext applicationDbContext;
            _context = context;
            _repository = _context.Set<User>();
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<TView> AuthenticateAsync<TView>(Authenticate model)
            where TView : IViewOf<User>
        {

            throw new NotImplementedException();
        }

        public async Task<Tuple<TView?, IEnumerable<IdentityError>>> CreateAsync<TView>(ViewModels.Users.Create createView)
            where TView : class, IViewOf<User>
        {
            var toCreate = _mapper.Map<User>(createView);
            var newUser = _repository.Add(toCreate).Entity;

            await _context.SaveChangesAsync();

            var appUser = _mapper.Map<ApplicationUser>(createView);

            appUser.UserId = newUser.Id;
            var createResult = await _userManager.CreateAsync(appUser, createView.Password);

            if (createResult.Succeeded)
            {
                var result = _mapper.Map<TView>(newUser);
                _mapper.Map(appUser, result);

                return new Tuple<TView?, IEnumerable<IdentityError>>(result, Array.Empty<IdentityError>());
            }
            else
            {
                _repository.Remove(newUser);
                await _context.SaveChangesAsync();
                return new Tuple<TView?, IEnumerable<IdentityError>>(default, createResult.Errors);
            }
        }

        public Task<IEnumerable<TView>> CreateAsync<TView>(Create[] createViews) where TView : IViewOf<User>
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<User, bool>>? filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes) where TView : IViewOf<User>
        {
            var query = _repository.AsNoTracking();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(User)))
            {
                query = query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (User)x);
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
            {
                var orderedQuery = orderBy(query.ProjectTo<TView>(_mapper.ConfigurationProvider));

                if (skip.HasValue && take.HasValue)
                    return await orderedQuery.Skip(skip.Value).Take(take.Value).ToArrayAsync();

                return await orderedQuery.ToArrayAsync();
            }

            var userIds = await query.Select(x => x.Id).ToArrayAsync();

            var appResult = await _userManager.Users.Where(x => userIds.Contains(x.UserId))
                .ProjectTo<TView>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

            var result = await query.ToArrayAsync();

            _mapper.Map(result, appResult);

            return appResult;
        }

        public Task<IEnumerable<TView>> GetAsync<TView>(Expression<Func<User, TView>> select, Expression<Func<User, bool>>? filter = null, Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null, int? skip = null, int? take = null, params string[] includes) where TView : IViewOf<User>
        {
            throw new NotImplementedException();
        }

        public Task<TView> GetByIdAsync<TView>(Guid id) where TView : IViewOf<User>
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<TView>> GetByIdAsync<TView>(IEnumerable<Guid> ids) where TView : IViewOf<User>
        {
            throw new NotImplementedException();
        }

        public Task<TView> UpdateAsync<TView>(Guid id, IUpdateView<User> updateView) where TView : IViewOf<User>
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TView>> UpdateAsync<TView>(IBatchUpdateView<User>[] updateViews) where TView : IViewOf<User>
        {
            throw new NotImplementedException();
        }
    }
}
