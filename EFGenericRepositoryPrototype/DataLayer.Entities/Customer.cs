using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Installation> Installations { get; set; }
    }
}
