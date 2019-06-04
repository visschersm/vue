using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(IContext context)
            : base(context)
        {
        }

        public IEnumerable<Blog> GetLatestBlogs(int amount = 5)
        {
            return _context.Blogs.OrderBy(x => x.CreatedDate).Take(5).ToArray();
        }

        public IEnumerable<Blog> GetTopBlogs(int pageIndex, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }
    }
}
