using Microsoft.EntityFrameworkCore;
using Xylem.Xdm.Database;

namespace DataProvider
{
    public class XcXdmModel : DbContext, IXdmModel
    {
        public DbSet<Installation> Installations { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}
