using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFLogger
{
    class Program
    {
        public class Blog
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class MainContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseLoggerFactory(MyLoggerFactor)
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFLogger;Integrated Security=True");


        }

        //public static readonly ILoggerFactory MyLoggerFactor
        //    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public class MyLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                throw new NotImplementedException();
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                throw new NotImplementedException();
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                throw new NotImplementedException();
            }
        }

        public class MyLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        public class MyLoggerFactor : ILoggerFactory
        {
            public void AddProvider(ILoggerProvider provider)
            {
                throw new NotImplementedException();
            }

            public ILogger CreateLogger(string categoryName)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {
            var loggerFactory = new MyLoggerFactor();

            loggerFactory.AddProvider(new MyLoggerProvider());

            //var logger = MyLoggerFactor.CreateLogger();
            using (var context = new MainContext())
            {
                context.Blogs.Add(new Blog { Name = "First blog" });
                context.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
