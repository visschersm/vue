using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestConsole
{
    public class BlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public Blog[] GetAllBlogs<ViewType>()
        {
            return _unitOfWork.Blogs.GetAll().ToArray();
        }
    }

    public class OtherBlogService
    {
        private readonly IContext _context;

        public OtherBlogService(IContext context)
        {
            _context = context;
        }

        public Blog[] GetAllBlogs<ViewType>()
        {
            return _context.Blogs.AsNoTracking()
                .ToArray();
        }
    }
}
