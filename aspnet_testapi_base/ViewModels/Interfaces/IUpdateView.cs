using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IUpdateView<TEntity> : IViewOf<TEntity>
        where TEntity : class, IEntity
    {
    }
}
