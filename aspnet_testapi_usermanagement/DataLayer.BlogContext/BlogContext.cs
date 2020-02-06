using DataLayer.API.Interfaces;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.API
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogContext;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }
        }
    }
}
