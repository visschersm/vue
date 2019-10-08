using DataLayer;
using ServiceLayer;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                var userService = new UserService(context);
                var user = userService.Create(new ViewLayer.User.Create
                {
                    Firstname = "Mark",
                    Lastname = "Visschers",
                    Username = "mvisschers",
                    Password = "W8woord1"
                });

                var blogService = new BlogService(context);

                blogService.Create(new ViewLayer.Blog.Create
                {
                    CreatedBy = user,
                    Title = "First Blog"
                });
            }
        }
    }
}
