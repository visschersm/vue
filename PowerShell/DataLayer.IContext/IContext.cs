using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public interface IContext
    {
        DbSet<Todo> Todos { get; set; }
    }
}
