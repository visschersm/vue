using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DbModel
{
    public interface IContext
    {
        IDbSet<Customer> Customers { get; set; }
    }
}
