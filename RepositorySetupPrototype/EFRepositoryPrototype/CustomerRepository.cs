using EFRepositoryPrototype.DbModel;
using EFRepositoryPrototype.DbModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFRepositoryPrototype
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MainContext context)
            : base(context)
        {

        }

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers.AsNoTracking()
                .SingleOrDefault(x => string.Compare(x.Name, name, true) == 0);
        }
    }
}
