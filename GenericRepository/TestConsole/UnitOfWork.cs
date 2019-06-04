using System.Threading.Tasks;

namespace TestConsole
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;

        public IBlogRepository Blogs { get; private set; }

        public IPostRepository Posts { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(IContext context)
        {
            _context = context;
            Blogs = new BlogRepository(context);
            Users = new UserRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
