using EFRepositoryPrototype.DbModel;
using System;
using System.Threading.Tasks;

namespace EFRepositoryPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new MainContext();

            var customerService = new CustomerService(context);

            customerService.AddCustomer("Customer1");
            var customers = await customerService.GetAllCustomersAsync();
        }
    }
}
