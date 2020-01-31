using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface ICreateView<TEntity> : IViewOf<TEntity>
        where TEntity : class, IEntity
    {
    }
}
