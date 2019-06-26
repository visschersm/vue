using EFRepositoryPrototype.DbModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFRepositoryPrototype
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByName(string name);
    }
}
