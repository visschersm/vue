using DataLayer.Entities.Interfaces;
using ViewModels.Interfaces;

namespace ViewModels
{
    public abstract class PrimaryKeyBase<TEntity> : IPrimaryKey<TEntity>
        where TEntity : class, IEntity
    {
        public object Id { get; } = null!;
    }
}
