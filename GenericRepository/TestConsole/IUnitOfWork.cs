using System;
using System.Threading.Tasks;

namespace TestConsole
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        IUserRepository Users { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
