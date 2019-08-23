using DbModel;

namespace DAL
{
    public class InstallationRepository
    {
        private readonly IContext _context;

        public InstallationRepository(IContext context)
        {
            _context = context;
        }


    }
}
