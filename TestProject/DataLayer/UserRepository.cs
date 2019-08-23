using DbModel;


namespace DataLayer
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IContext context)
            : base(context)
        {
        }
    }
}
