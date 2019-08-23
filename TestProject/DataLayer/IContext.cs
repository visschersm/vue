using DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public interface IContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Dispose();

        int SaveChanges();
    }
}
