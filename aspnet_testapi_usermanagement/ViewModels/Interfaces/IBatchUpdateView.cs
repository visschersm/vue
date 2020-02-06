using DataLayer.Entities.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IBatchUpdateView<TEntity> where TEntity : class, IEntity
    {
    }
}
