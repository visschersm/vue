using DbModel;

namespace DataLayer
{
    public class BlogRepository : BaseRepository<Blog>
    {
        public BlogRepository(IContext context)
            : base(context)
        {

        }
    }
}
