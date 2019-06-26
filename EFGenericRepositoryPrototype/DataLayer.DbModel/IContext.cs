using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer.DbModel
{
    public interface IContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Contract> Contracts { get; set; }
        DbSet<Installation> Installations { get; set; }
        DbSet<ContractInstallation> ContractInstallations { get; set; }
    }
}
