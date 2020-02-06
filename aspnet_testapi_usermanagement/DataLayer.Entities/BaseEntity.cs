using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer
{
    public abstract class BaseEntity<TKey> : IBaseEntity, IEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        object IEntity.Id => Id;
    }
}
