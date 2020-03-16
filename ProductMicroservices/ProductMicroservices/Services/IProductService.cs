using ProductMicroservices.Models;
using System.Collections.Generic;

namespace ProductMicroservices.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product GetById(int id);
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
    }
}
