using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DbModel
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IContext context)
            : base(context)
        {

        }

        public ViewType GetCustomerByName<ViewType>(string name)
        {
            _context.Customers.AsNoTracking().
        }
    }
}
