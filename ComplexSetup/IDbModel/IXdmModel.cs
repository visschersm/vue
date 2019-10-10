using Microsoft.EntityFrameworkCore;
using Xylem.Xdm.Database;

namespace DataProvider
{
    public interface IXdmModel
    {
        DbSet<Installation> Installations { get; set; }
        DbSet<Template> Templates { get; set; }
    }
}
