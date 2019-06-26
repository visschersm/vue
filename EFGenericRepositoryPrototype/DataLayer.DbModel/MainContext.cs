using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DbModel
{
    public class MainContext : DbContext, IContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Installation> Installations { get; set; }
        public DbSet<ContractInstallation> ContractInstallations { get; set; }
    }
}
