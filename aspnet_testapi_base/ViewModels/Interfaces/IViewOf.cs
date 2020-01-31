using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IViewOf<TEntity> where TEntity : class, IEntity
    {
    }
}
