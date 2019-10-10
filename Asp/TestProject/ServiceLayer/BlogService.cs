using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BlogService
    {
        //private readonly IBlogContext _context;
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        //public BlogService(IBlogContext context, IConfigurationProvider configuration)

        public BlogService(BlogContext context, IMapper mapper)
        {
            _context = context;
            _context.Blogs.Add(new Blog { Name = "Blog1" });
            _context.SaveChanges();

            _mapper = mapper;
        }

        public async IAsyncEnumerable<TView> GetAsync<TView>()
        {
            await foreach (var blog in _context.Blogs.ProjectTo<TView>(_mapper.ConfigurationProvider).AsAsyncEnumerable())
            {
                yield return blog;
            }
        }

        public async Task<TView> CreateAsync<TView>(ViewModels.Blog.Create newBlog)
        {
            var blog = new Blog
            {
                Name = newBlog.Name,
                CreatedDate = DateTime.Now.Date,
                CreatedById = newBlog.CreatedById
            };

            var createdBlog = _context.Blogs.Add(blog).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<TView>(createdBlog);
        }
    }
}
