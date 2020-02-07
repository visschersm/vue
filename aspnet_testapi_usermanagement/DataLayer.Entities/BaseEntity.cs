using DataLayer.Entities.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DataLayer
{
    public abstract class BaseEntity<TKey> : IBaseEntity, IEntity<TKey>
    {
        [DisallowNull]
        public TKey Id { get; set; } = default;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        object IEntity.Id => Id;
    }
}
