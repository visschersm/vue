using System;

namespace DataLayer.Entities.Interfaces
{
    interface IBaseEntity<TKey> : IEntity<TKey>
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
