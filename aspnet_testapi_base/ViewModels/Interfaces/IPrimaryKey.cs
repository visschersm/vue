using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IPrimaryKey<TEntity> : IViewOf<TEntity>
        where TEntity : class, IEntity
    {
        object Id { get; }
    }

    public interface IPrimaryKey<TKey, TEntity> : IPrimaryKey<TEntity>
        where TEntity : class, IEntity<TKey>
    {
        new TKey Id { get; set; }
    }
}
