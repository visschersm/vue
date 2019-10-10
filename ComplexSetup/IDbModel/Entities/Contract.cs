using System;
using System.Collections.Generic;

namespace Xylem.Xdm.Database
{
    public class Contract
    {
        public Contract()
        {
            //ContractContacts = new HashSet<ContractContact>();
            //ContractInstallations = new HashSet<ContractInstallation>();
            //ContractPricelists = new HashSet<ContractPricelist>();
            //InstallationPlannings = new HashSet<InstallationPlanning>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? ClientId { get; set; }
        public int? ContractorId { get; set; }
        public int? SubcontractorId { get; set; }
        public int? ContractManagerId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? InvoiceTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remark { get; set; }
        public decimal? Price { get; set; }
        public string Reference { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? OldId { get; set; }

        public Customer Client { get; set; }
        public Customer ContractManager { get; set; }
        //public Selection ContractType { get; set; }
        public Customer Contractor { get; set; }
        public Customer Customer { get; set; }
        //public Selection InvoiceType { get; set; }
        public Customer Subcontractor { get; set; }
        //public ICollection<ContractContact> ContractContacts { get; set; }
        //public ICollection<ContractInstallation> ContractInstallations { get; set; }
        //public ICollection<ContractPricelist> ContractPricelists { get; set; }
        //public ICollection<InstallationPlanning> InstallationPlannings { get; set; }
        public ICollection<Report> Reports { get; set; }

        public string EventDescription => Name;
    }
}
