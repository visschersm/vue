using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<TView> CreateAsync<TView>(ViewModel.User.Create toCreate);
        Task<IEnumerable<TView>> GetAsync<TView>();
        Task<TView> GetByIdAsync<TView>(int id);
        Task<TView> UpdateAsync<TView>(int id, ViewModel.User.Update toUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
