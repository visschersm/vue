using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.API.Interfaces
{
    public interface IBlogContext : IDataContext
    {
        DbSet<Blog> Blogs { get; set; }
    }
}
