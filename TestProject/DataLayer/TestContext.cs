using DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TestContext : DbContext, IContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }

        public TestContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
            }
        }
    }
}
