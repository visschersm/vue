using System;
using Xylem.Xdm.Database.Attributes;

namespace Xylem.Xdm.Database
{
    public class Template
    {
        public Template()
        {
            //EquipmentGroups = new HashSet<TemplateEquipmentGroup>();
            //Fields = new HashSet<TemplateField>();
            //ReportFields = new HashSet<TemplateReportField>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        [TrackChanges]
        public string Description { get; set; }
        [TrackChanges]
        public string Code { get; set; }
        [TrackChanges]
        public string Color { get; set; }
        [TrackChanges]
        public decimal? InstallationsPerDay { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Company Company { get; set; }
        //public ICollection<TemplateEquipmentGroup> EquipmentGroups { get; set; }
        //public ICollection<TemplateField> Fields { get; set; }
        //public ICollection<TemplateReportField> ReportFields { get; set; }

        public string EventDescription => Description;
    }
}
