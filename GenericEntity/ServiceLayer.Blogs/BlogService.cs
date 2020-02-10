using AutoMapper;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Blogs
{
    public class BlogService : BaseService<int, Blog>
    {
        public BlogService(DbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
