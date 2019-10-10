using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Database
{
    public class DataModel : DbContext, IDataModel
    {
        public DbSet<User> Users { get; set; }

        public DataModel()
        {
        }

        public DataModel(DbContextOptions<DataModel> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=(localdb)\mssqllocaldb;Database=ct_postgres;Host=host.docker.internal;Username=ct_user;Password=password;Integrated Security=True");
        }
    }
}
