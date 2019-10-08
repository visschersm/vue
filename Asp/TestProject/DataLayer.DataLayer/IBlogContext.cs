using Microsoft.EntityFrameworkCore;

namespace DataLayer.DbModel
{
    public interface IBlogContext
    {
        DbSet<Blog> Blogs { get; }
        DbSet<Post> Posts { get; }
        DbSet<Comment> Comments { get; }
        DbSet<User> Users { get; }

        void SaveChanges();
    }
}
