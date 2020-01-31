using AutoMapper;
using DataLayer.Entities.Interfaces;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer
{
    public abstract class BaseService<TEntity> : IGenericService<TEntity>
        where TEntity : class, IEntity
    {
        //private DbContext
        private readonly IDataContext _context;
        private readonly DbSet<TEntity> _repository;
        private readonly IMapper _mapper;

        protected BaseService(IDataContext context, IMapper mapper)
        {
            _context = context;
            _repository = context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<TView> CreateAsync<TCreate, TView>(TCreate createView)
            where TCreate : ICreateView<TEntity>
            where TView : IViewOf<TEntity>
        {
            var newEntity = _mapper.Map<TEntity>(createView);

            var createdEntity = _repository.Add(newEntity).Entity;
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView>(createdEntity);

            return result;
        }

        public async Task<IEnumerable<TView>> CreateAsync<TCreate, TView>(TCreate[] createViews)
            where TCreate : ICreateView<TEntity>
            where TView : IViewOf<TEntity>
        {
            var newEntities = _mapper.Map<TEntity>(createViews);

            _repository.AddRange(newEntities);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView[]>(newEntities);

            return result;

        }

        public async Task DeleteAsync<TKey>(TKey id)
            where TKey : IEquatable<TKey>
        {
            var entity = await _repository.Where(x => x.Id.Equals(id))
                .SingleOrDefaultAsync();

            if (entity == null)
                throw new ArgumentNullException($"No entity found with {nameof(id)}: {id}");

            _repository.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>> orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes)
            where TView : IViewOf<TEntity>
        {
            IQueryable<TEntity> query = _repository.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach (var include in includes)
                query = query.Include(include);

            var selectedQuery = _mapper.ProjectTo<TView>(query);

            if (orderBy != null)
            {
                selectedQuery = orderBy(selectedQuery).AsQueryable();
            }

            if (skip.HasValue)
                selectedQuery = selectedQuery.Skip(skip.Value);

            if (take.HasValue)
                selectedQuery = selectedQuery.Take(take.Value);

            return await selectedQuery.ToArrayAsync();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<TEntity, TView>> select,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>> orderBy = null,
            int? skip = null,
            int? take = null,
            params string[] includes) where TView : IViewOf<TEntity>
        {
            IQueryable<TEntity> query = _repository.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach (var include in includes)
                query = query.Include(include);

            var selectedQuery = query.Select(select);

            if (orderBy != null)
            {
                selectedQuery = orderBy(selectedQuery).AsQueryable();
            }

            if (skip.HasValue)
                selectedQuery = selectedQuery.Skip(skip.Value);

            if (take.HasValue)
                selectedQuery = selectedQuery.Take(take.Value);

            return await selectedQuery.ToArrayAsync();
        }

        public async Task<TView> GetByIdAsync<TKey, TView>(TKey id)
            where TKey : IEquatable<TKey>
            where TView : IViewOf<TEntity>
        {
            var result = await _mapper.ProjectTo<TView>(
                _repository.AsNoTracking()
                .Where(x => x.Id.Equals(id)))
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<TView>> GetByIdAsync<TKey, TView>(
            IEnumerable<TKey> ids)
            where TView : IViewOf<TEntity>
        {
            var result = await _mapper.ProjectTo<TView>(
                _repository.AsNoTracking()
                .Where(x => ids.Contains((TKey)x.Id)))
                .ToArrayAsync();

            return result;
        }

        public Task<TView> UpdateAsync<TKey, TUpdate, TView>(TKey id, TUpdate updateView)
            where TKey : IEquatable<TKey>
            where TUpdate : IUpdateView<TEntity>
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TView>> UpdateAsync<TUpdate, TView>(TUpdate[] updateViews)
            where TUpdate : IBatchUpdateView<TEntity>
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
