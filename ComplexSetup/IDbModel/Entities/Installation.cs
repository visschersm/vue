using System;
using System.Collections.Generic;
using Xylem.Xdm.Database.Attributes;

namespace Xylem.Xdm.Database
{
    public class Installation
    {
        public Installation()
        {
            //ContractInstallations = new HashSet<ContractInstallation>();
            //InstallationEquipment = new HashSet<InstallationEquipment>();
            //FieldValues = new HashSet<InstallationFieldValue>();
            //InstallationFinancial = new HashSet<InstallationFinancial>();
            //InstallationLog = new HashSet<InstallationLog>();
            //InstallationPlanning = new HashSet<InstallationPlanning>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string XCloudId { get; set; }
        public int CustomerId { get; set; }
        public string XCloudCustomerId { get; set; }
        public int? TemplateId { get; set; }

        [TrackChanges]
        public string Name { get; set; }
        [TrackChanges]
        public string Address { get; set; }
        [TrackChanges]
        public string City { get; set; }
        [TrackChanges]
        public string Zipcode { get; set; }
        [TrackChanges]
        public short? Year { get; set; }
        [TrackChanges]
        public string ExternalKey { get; set; }
        [TrackChanges]
        public decimal? Latitude { get; set; }
        [TrackChanges]
        public decimal? Longitude { get; set; }
        [TrackChanges]
        public string Reference { get; set; }
        [TrackChanges]
        public string Remark { get; set; }
        [TrackChanges]
        public string GroupName { get; set; }
        [TrackChanges]
        public string Project { get; set; }
        [TrackChanges]
        public byte? RiskProfile { get; set; }
        [TrackChanges]
        public string RiskMatrix { get; set; }
        [TrackChanges]
        public byte? CleaningProfile { get; set; }
        [TrackChanges]
        public byte? MaintenanceProfileField { get; set; }
        [TrackChanges]
        public int? MaintenanceProfileId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Customer Customer { get; set; }
        public Template Template { get; set; }
        //public MaintenanceProfile MaintenanceProfile { get; set; }
        //public ICollection<ContractInstallation> ContractInstallations { get; set; }
        //public ICollection<InstallationEquipment> InstallationEquipment { get; set; }
        //public ICollection<InstallationFieldValue> FieldValues { get; set; }
        //public ICollection<InstallationFinancial> InstallationFinancial { get; set; }
        //public ICollection<InstallationLog> InstallationLog { get; set; }
        //public ICollection<InstallationPlanning> InstallationPlanning { get; set; }
        public ICollection<Report> Reports { get; set; }

        public string EventDescription => Name;
    }
}
