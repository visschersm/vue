using System.ComponentModel.DataAnnotations;

// https://cpratt.co/generic-entity-base-class/

namespace DataLayer.Entities.Interfaces
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<TKey> : IEntity
    {
        [Key]
        new TKey Id { get; set; }
    }
}
