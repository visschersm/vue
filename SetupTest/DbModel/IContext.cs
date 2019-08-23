using Entities;
using Microsoft.EntityFrameworkCore;

namespace DbModel
{
    public interface IContext
    {
        DbSet<IReport> Reports { get; set; }
    }
}
