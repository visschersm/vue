using System;

namespace EFGenericRepositoryPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MainContext())
            {
                var customerService = new CustomerService(context)
            }
        }
    }
}
