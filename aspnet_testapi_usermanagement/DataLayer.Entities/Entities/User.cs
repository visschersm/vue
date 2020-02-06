using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer.Entities
{
    public class User : BaseEntity<int>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
    }
}
