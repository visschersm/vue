using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestConsole
{
    public class MainContext : DbContext, IContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        private readonly string _connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<User>().Property(x => x.Fullname).HasComputedColumnSql("[Firstname]+' '+[Lastname]");
        }
    }
}
