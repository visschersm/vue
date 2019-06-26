using EFRepositoryPrototype.DbModel;
using EFRepositoryPrototype.DbModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFRepositoryPrototype
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly MainContext _context;

        public CustomerService(MainContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository(context);
        }

        public bool AddCustomer(string name)
        {
            if (_customerRepository.GetCustomerByName(name) != null)
                return false;

            _customerRepository.Add(new Customer
            {
                Name = name
            });

            _context.SaveChanges();
            return true;
        }

        public Customer GetCustomerByName(string name)
        {
            return _customerRepository.GetCustomerByName(name);
        }

        public async Task<Customer[]> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAsync();
        }
    }
}
