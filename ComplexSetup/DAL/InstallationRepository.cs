using DataProvider;

namespace Xylem.DAL
{
    public class InstallationRepository
    {
        private readonly IXdmModel _context;

        public InstallationRepository(IXdmModel context)
        {
            _context = context;
        }
    }
}
