using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer
{
    public abstract class BaseService<TKey, TEntity> : IGenericService<TKey, TEntity>
        where TEntity : class, IId<TKey>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(DbContext context, IMapper mapper)
        {
            _context = context;
            _repository = context.Set<TEntity>();

            _mapper = mapper;
        }

        public async Task<TView> CreateAsync<TView>(ICreateView<TEntity> createView)
        {
            var toCreate = _mapper.Map<TEntity>(createView);

            var newEntity = _repository.Add(toCreate).Entity;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView>(newEntity);

            return result;
        }

        public async Task<IEnumerable<TView>> GetAllAsync<TView>()
        {
            var query = _repository.AsNoTracking();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (TEntity)x);
            }

            var result = await query.ProjectTo<TView>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

            return result;
        }

        public async Task<TView> GetByIdAsync<TView>(IId<TKey> id)
        {
            var query = _repository.AsNoTracking();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (TEntity)x);
            }

            query = query.Where(x => x.Id.Equals(id.Id));

            var result = await query.ProjectTo<TView>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<TView> UpdateAsync<TView>(IId<TKey> id, IUpdateView<TEntity> updateView)
        {
            var query = _repository.AsQueryable();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (TEntity)x);
            }

            query = query.Where(x => x.Id.Equals(id.Id));

            var toUpdate = await query.SingleOrDefaultAsync();

            _mapper.Map(updateView, toUpdate);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TView>(toUpdate);

            return result;
        }

        public async Task DeleteAsync(IId<TKey> id)
        {
            var query = _repository.AsQueryable();
            query = query.Where(x => x.Id.Equals(id.Id));

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                await SoftDeleteImplAsync(query);
                return;
            }

            var toDelete = await query.SingleOrDefaultAsync();


        }

        private async Task SoftDeleteImplAsync(IQueryable<TEntity> query)
        {
            var toDelete = await query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .SingleOrDefaultAsync();

            toDelete.DeletedOn = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
