using AutoMapper;
using DataLayer.Entities;

namespace ServiceLayer.Blogs
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<Blogs.Views.Create, Blog>();
            CreateMap<Blog, Blogs.Views.Simple>();
            CreateMap<Blog, Blogs.Views.Full>();
            CreateMap<Blog, Blogs.Views.List>();
        }
    }
}
