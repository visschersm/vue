using System;
using System.Collections.Generic;
using Xylem.Xdm.Database.Attributes;

namespace Xylem.Xdm.Database
{
    public class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
            ContractClients = new HashSet<Contract>();
            ContractContractManagers = new HashSet<Contract>();
            ContractContractors = new HashSet<Contract>();
            ContractSubcontractors = new HashSet<Contract>();
            //CustomerAddresses = new HashSet<CustomerAddress>();
            //CustomerContacts = new HashSet<CustomerContact>();
            Installations = new HashSet<Installation>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        [TrackChanges]
        public string Name { get; set; }
        [TrackChanges]
        public string Email { get; set; }
        [TrackChanges]
        public string AccountNumber { get; set; }
        [TrackChanges]
        public string Phone1 { get; set; }
        [TrackChanges]
        public string Phone2 { get; set; }
        [TrackChanges]
        public string Remark { get; set; }
        [TrackChanges]
        public string Language { get; set; }
        [TrackChanges]
        public string Reference { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? CustomerMaintenanceProfileId { get; set; }

        //public CustomerMaintenanceProfile CustomerMaintenanceProfile { get; set; }
        public ICollection<Contract> ContractClients { get; set; }
        public ICollection<Contract> ContractContractManagers { get; set; }
        public ICollection<Contract> ContractContractors { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Contract> ContractSubcontractors { get; set; }
        //public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        //public ICollection<CustomerContact> CustomerContacts { get; set; }
        public ICollection<Installation> Installations { get; set; }
        //public ICollection<RiskMatrixColumn> RiskMatrixColumns { get; set; }
        //public ICollection<MaintenanceProfile> MaintenanceProfiles { get; set; }

        public string EventDescription => Name;
    }
}
