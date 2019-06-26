using EFRepositoryPrototype.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepositoryPrototype
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private protected MainContext _context;

        public Repository(MainContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity[]> GetAsync()
        {
            return await _context.Set<TEntity>().ToArrayAsync();
        }
    }
}
