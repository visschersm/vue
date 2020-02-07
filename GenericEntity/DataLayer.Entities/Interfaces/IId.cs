using System;

namespace DataLayer.Entities.Interfaces
{
    public interface IId<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        TKey Id { get; set; }
    }
}
