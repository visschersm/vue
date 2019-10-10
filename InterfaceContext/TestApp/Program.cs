using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Mvc;

namespace TestApp
{
    public class Blog
    {
        public int Id { get; set; }
    }

    public interface IContext
    {
        DbSet<Blog> Blogs { get; set; }

        int SaveChanges();
    }

    public class MyContext : DbContext, IContext
    {
        public DbSet<Blog> Blogs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class MyOtherContext : DbContext, IContext
    {
        public DbSet<Blog> Blogs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public interface IBlogService
    {
        public void CreateBlog(Blog blog);
    }

    public abstract class BaseBlogService : IBlogService
    {
        private readonly IContext _context;

        public BaseBlogService(IContext context)
        {
            _context = context;
        }

        public void CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
    }

    public class MyBlogService : BaseBlogService
    {
        public MyBlogService(MyContext context)
            : base(context)
        {

        }
    }

    public class MyOtherBlogService : BaseBlogService
    {
        public MyOtherBlogService(MyOtherContext context)
            : base(context)
        {

        }
    }

    public class InterfacedController : Controller
    {

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
