using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        public class Blog
        {
            public string Name { get; set; }
        };

        public class MyContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static async IAsyncEnumerable<Blog> GetResultsAsync()
        {
            for (int i = 0; i < 500; ++i)
            {
                //List<Blog> blogs = new List<Blog>();
                //blogs.Add(new Blog { });

                if (i % 10 == 0)
                {
                    yield return new Blog { };
                }

                Thread.Sleep(100);
            }
        }

        static async IAsyncEnumerable<Blog> GetBlogs()
        {
            await foreach (var result in GetResultsAsync())
            {
                yield return result;
            }
        }


    }
}
