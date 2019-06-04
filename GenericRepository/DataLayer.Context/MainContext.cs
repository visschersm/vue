using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}
