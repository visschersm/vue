using EFRepositoryPrototype.DbModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFRepositoryPrototype.DbModel
{
    public class MainContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public MainContext()
        {
            
        }
    }
}
