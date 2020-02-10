using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer.Interfaces
{
    public interface IGenericService<TKey, TEntity>
    {
        Task<TView> CreateAsync<TView>(ICreateView<TEntity> createView);
        Task<TView> GetByIdAsync<TView>(IId<TKey> id);
        Task<IEnumerable<TView>> GetAllAsync<TView>();
        Task<TView> UpdateAsync<TView>(IId<TKey> id, IUpdateView<TEntity> updateView);
        Task DeleteAsync(IId<TKey> id);
    }
}
