using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer.Entities.Entities
{
    public class User : BaseEntity<Guid>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
    }
}
