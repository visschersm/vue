using AutoMapper;
using DataLayer.Entities;

namespace ViewModels.Blogs
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<ViewModels.Blogs.Create, Blog>();
            CreateMap<Blog, ViewModels.Blogs.Simple>();
            CreateMap<Blog, ViewModels.Blogs.Full>();
            CreateMap<Blog, ViewModels.Blogs.List>();
        }
    }
}
