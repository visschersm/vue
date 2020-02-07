using DataLayer.Entities;
using DataLayer.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ServiceLayer.Blogs
{
    public class BlogService<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        private readonly DbContext _context;
        private readonly DbSet<Blog> _repository;

        public BlogService(DbContext context)
        {
            _context = context;
            _repository = _context.Set<Blog>();
        }

        public async Task<TView> GetByIdAsync<TView>(TKey id)
        {
            var query = _repository.AsNoTracking();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(Blog)))
            {
                query.Select(x => (ISoftDeletable)x)
                    .Where(x => !x.DeletedOn.HasValue)
                    .Select(x => (Blog)x);
            }

            query = query.AsNoTracking()
                .Where(x => x.Id.Equals(id));

            var result = await query.Select(ViewHelper<Blog, TView>.SelectExpression)
                .SingleOrDefaultAsync();

            return result;
        }
    }
}
