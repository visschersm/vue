using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer.Entities
{
    public class User : IId<Guid>
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
