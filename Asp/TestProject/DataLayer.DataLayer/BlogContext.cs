using Microsoft.EntityFrameworkCore;

namespace DataLayer.DbModel
{
    public class BlogContext : DbContext//, IBlogContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }
    }
}
