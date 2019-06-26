using DataLayer.DbModel;
using ServiceLayer;
using System;

namespace GenericRepositoryPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MainContext())
            {
                var customerService = new CustomerService(context);
                //customerService.Add()
            }
        }
    }
}
