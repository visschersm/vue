using System;

namespace Xylem.Xdm.Database
{
    public class Report
    {
        public Report()
        {
            //ReportArticles = new HashSet<ReportArticle>();
            //ReportEquipmentGroups = new HashSet<ReportEquipmentGroup>();
            //ReportFields = new HashSet<ReportField>();
            //ReportMalfunctions = new HashSet<ReportMalfunction>();
            //ReportRemarks = new HashSet<ReportRemark>();
            //ReportTasks = new HashSet<ReportTask>();
        }

        public int Id { get; set; }
        public int? ContractId { get; set; }
        public int InstallationId { get; set; }
        public int ProjectManagerId { get; set; }
        public int? MechanicId { get; set; }
        public decimal? MechanicLatitude { get; set; }
        public decimal? MechanicLongitude { get; set; }
        public byte? ProcessStatus { get; set; }
        public byte ReportType { get; set; }
        public byte Round { get; set; }
        public byte Status { get; set; }
        public byte Priority { get; set; }
        public bool SkipApproval { get; set; }
        public string CustomerRemark { get; set; }
        public string ContractRemark { get; set; }
        public string InstallationRemark { get; set; }
        public DateTime? PerformOn { get; set; }
        public DateTime? PerformedOn { get; set; }
        public DateTime? PerformBefore { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Contract Contract { get; set; }
        //public User CreatedBy { get; set; }
        public Installation Installation { get; set; }
        //public User Mechanic { get; set; }
        //public User ProjectManager { get; set; }
        //public ICollection<ReportArticle> ReportArticles { get; set; }
        //public ICollection<ReportEquipmentGroup> ReportEquipmentGroups { get; set; }
        //public ICollection<ReportField> ReportFields { get; set; }
        //public ICollection<ReportMalfunction> ReportMalfunctions { get; set; }
        //public ICollection<ReportRemark> ReportRemarks { get; set; }
        //public ICollection<ReportTask> ReportTasks { get; set; }

        //public string EventDescription => $"{Installation?.EventDescription} - { CreatedBy?.Initials } { CreatedOn.ToString("dd-MM-yyyy HH:mm") }";
    }
}
