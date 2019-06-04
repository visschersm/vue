using DataLayer.Entities;
using System.Collections.Generic;

namespace TestConsole
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetTopBlogs(int pageIndex, int pageSize = 10);
        IEnumerable<Blog> GetLatestBlogs(int amount = 5);
    }
}
