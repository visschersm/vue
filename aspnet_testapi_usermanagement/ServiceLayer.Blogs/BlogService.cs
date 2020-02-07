using AutoMapper;
using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;

namespace ServiceLayer.Blogs
{
    public class BlogService : BaseService<Guid, Blog>, IBlogService
    {
        public BlogService(IDataContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
