using DataLayer.DbModel;
using DataLayer.Entities;
using System;

namespace EFRepositoryPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MainContext())
            {
                context.Customers.Add(new Customer
                {
                    Name = "Customer 1"
                });

                context.SaveChanges();
            }
        }
    }
}
