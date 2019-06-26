using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ContractInstallation
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public int InstallationId { get; set; }
        public Installation Installation { get; set; }
    }
}
