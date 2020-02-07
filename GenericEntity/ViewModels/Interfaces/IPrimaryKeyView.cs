using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IPrimaryKeyView<TKey, TEntity> : IViewOf<TEntity>
        where TEntity : IId<TKey>
    {
    }
}
