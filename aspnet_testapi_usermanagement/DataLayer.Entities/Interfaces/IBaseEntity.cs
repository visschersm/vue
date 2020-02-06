using System;

namespace DataLayer.Entities.Interfaces
{
    interface IBaseEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
