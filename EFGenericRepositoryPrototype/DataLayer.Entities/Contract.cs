using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Contract
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public ICollection<ContractInstallation> ContractInstallations { get; set; }
    }
}
