using DataLayer.Entities.Interfaces;

namespace DataLayer
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        object IEntity.Id => Id;
    }
}
