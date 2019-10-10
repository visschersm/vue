using Microsoft.EntityFrameworkCore;
using Xylem.Xdm.Database;

namespace DataProvider
{
    public class XdmModel : DbContext, IXdmModel
    {
        public DbSet<Installation> Installations { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}
