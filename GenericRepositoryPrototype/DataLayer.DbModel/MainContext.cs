using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataLayer.DbModel
{
    public class MainContext : DbContext, IContext
    {
        public DbSet<Customer> Customers { get; set; }
        IDbSet<Customer> IContext.Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MainContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated security=SSPI");
        }
    }
}
