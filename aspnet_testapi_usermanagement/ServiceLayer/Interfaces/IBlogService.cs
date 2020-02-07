using DataLayer.Entities;
using System;

namespace ServiceLayer.Interfaces
{
    public interface IBlogService : IGenericService<Guid, Blog>
    {
    }
}
