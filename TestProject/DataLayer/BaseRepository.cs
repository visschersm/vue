using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected IContext _context;
        protected DbSet<TEntity> _set;
        public BaseRepository(IContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TView>> select)
        {
            return await _context.Set<TEntity>().Where(where).Select(select).ToArrayAsync();
        }

        public TEntity Create(TEntity user)
        {
            return _set.Add(user).Entity;
        }
    }
}
