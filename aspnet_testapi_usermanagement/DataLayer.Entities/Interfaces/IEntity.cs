using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// https://cpratt.co/generic-entity-base-class/

namespace DataLayer.Entities.Interfaces
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<TKey> : IEntity
    {
        [DisallowNull]
        [Key]
        new TKey Id { get; set; }
    }
}
