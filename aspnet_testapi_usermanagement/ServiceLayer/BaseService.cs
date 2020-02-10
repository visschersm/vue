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
    public abstract class BaseService<TKey, TEntity> : IGenericService<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly IDataContext _context;
        protected readonly DbSet<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(IDataContext context, IMapper mapper)
        {
            _context = context;
            _repository = context.Set<TEntity>();

            if (_repository == null)
                throw new ArgumentNullException(nameof(_repository));

            _mapper = mapper;
        }

        public async Task<TView?> CreateAsync<TView>(ViewModels.Interfaces.ICreateView<TEntity> createView)
            where TView : class, IViewOf<TEntity>
        {
            var newEntity = _mapper.Map<TEntity>(createView);

            var createdEntity = _repository.Add(newEntity).Entity;
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView>(createdEntity);

            return result;
        }

        public async Task<IEnumerable<TView>> CreateAsync<TView>(ViewModels.Interfaces.ICreateView<TEntity>[] createViews)
            where TView : IViewOf<TEntity>
        {
            var newEntities = _mapper.Map<TEntity>(createViews);

            _repository.AddRange(newEntities);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView[]>(newEntities);

            return result;

        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            //if (EqualityComparer<TKey>.Default.Equals(obj, default(TKey)))
            //{
            //    return obj;
            //}

            var entity = await _repository.Where(x => x.Id.Equals(id))
                .SingleOrDefaultAsync();

            if (entity == null)
                throw new ArgumentNullException($"No entity found with {nameof(id)}: {id}");

            _repository.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null,
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
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TView>, IOrderedQueryable<TView>>? orderBy = null,
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

        public async Task<TView> GetByIdAsync<TView>(TKey id)
            where TView : IViewOf<TEntity>
        {
            var result = await _mapper.ProjectTo<TView>(
                _repository.AsNoTracking()
                .Where(x => x.Id.Equals(id)))
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<TView>> GetByIdAsync<TView>(
            IEnumerable<TKey> ids)
            where TView : IViewOf<TEntity>
        {
            var result = await _mapper.ProjectTo<TView>(
                _repository.AsNoTracking()
                .Where(x => ids.Contains((TKey)x.Id)))
                .ToArrayAsync();

            return result;
        }

        public async Task<TView> UpdateAsync<TView>(TKey id, IUpdateView<TEntity> updateView)
            where TView : IViewOf<TEntity>
        {
            var query = _repository.AsQueryable();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (TEntity)x);
            }

            var toUpdate = await query.SingleOrDefaultAsync(x => x.Id.Equals(id));

            _mapper.Map(updateView, toUpdate);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView>(toUpdate);

            return result;
        }

        public Task<IEnumerable<TView>> UpdateAsync<TView>(ViewModels.Interfaces.IBatchUpdateView<TEntity>[] updateViews)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
