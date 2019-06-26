using DataLayer.DbModel;
using DataLayer.Entities;
using System;

namespace ServiceLayer
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IContext _context;
        public CustomerService(IContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository(context);
        }

        public ViewType GetCustomerByName<ViewType>(string name)
        {
            Repository<Customer> localCustomerRepo = new Repository<Customer>(_context);
            localCustomerRepo.GetAsync()
            return _customerRepository.GetCustomerByName(name);
        }
    }
}
