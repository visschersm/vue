using DataLayer;
using DbModel;
using System;

namespace ServiceLayer
{
    public class BlogService
    {
        private readonly BlogRepository _blogRepository;

        public BlogService(IContext context)
        {
            _blogRepository = new BlogRepository(context);
        }

        public ViewLayer.Blog.List Create(ViewLayer.Blog.Create blog)
        {
            var newBlog = _blogRepository.Create(new Blog
            {
                Title = blog.Title,
                CreatedById = blog.CreatedBy.Id,
                CreatedAt = DateTime.Today.Date
            });

            return new ViewLayer.Blog.List
            {
                Id = newBlog.Id,
                Title = newBlog.Title
            };
        }
    }
}
