using DataLayer.Entities;

namespace TestConsole
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IContext context) : base(context)
        {
        }
    }
}
