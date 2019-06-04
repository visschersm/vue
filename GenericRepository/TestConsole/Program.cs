using DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace TestConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            //var builder = new ConfigurationBuilder()
            //.SetBasePath(projectDirectory)
            //.AddJsonFile("appsettings.json");
            //
            //

            var builder = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddXmlFile("App1.config");

            var configuration = builder.Build();
            //using (var unitOfWork = new UnitOfWork(new MainContext(configuration.GetConnectionString("BloggingDatabase"))))
            using (var unitOfWork = new UnitOfWork(new MainContext()))
            {
                if (!unitOfWork.Users.Find(x => x.Fullname == "Mark Visschers" || x.Username == "m.visschers").Any())
                {
                    unitOfWork.Users.Add(new User
                    {
                        Username = "m.visschers",
                        Firstname = "Mark",
                        Lastname = "Visschers",
                        Password = "Change123!",
                    });

                    unitOfWork.SaveChanges();
                }

                var user = unitOfWork.Users.Find(x => x.Fullname == "Mark Visschers").FirstOrDefault();

                unitOfWork.Blogs.Add(new Blog
                {
                    Name = "First Blog",
                    CreatedById = user.Id,
                    CreatedDate = DateTime.Today,
                });

                unitOfWork.SaveChanges();

                var blogs = unitOfWork.Blogs.GetAll();

                var newestBlogs = unitOfWork.Blogs.GetLatestBlogs(10);
            }
        }
    }
}
