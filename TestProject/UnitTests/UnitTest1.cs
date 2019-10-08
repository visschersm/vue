using DataLayer;
using DbModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private IContext _context;

        [TestInitialize]
        public void Init()
        {
            _context = new DataLayer.TestContext();
        }

        [TestMethod]
        public void CreateBlog()
        {
            var user = _context.Users.Add(new User { }).Entity;

            _context.SaveChanges();

            var blogService = new BlogService(_context);

            var listUser = new ViewLayer.User.List
            {
                Id = user.Id,
                Username = user.Username
            };

            var newBlog = blogService.Create(new ViewLayer.Blog.Create
            {
                CreatedBy = listUser,
                Title = "Test Blog"
            });

            Assert.AreEqual("Test Blog", newBlog.Title);
        }

        [TestCleanup]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
