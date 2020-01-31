using AutoMapper;
using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Blogs
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(IDataContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
