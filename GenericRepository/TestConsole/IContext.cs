using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    public interface IContext
    {
        DbSet<Blog> Blogs { get; }
        DbSet<Post> Posts { get; }
        DbSet<User> Users { get; }
        DbSet<Comment> Comments { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
