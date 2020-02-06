using DataLayer.Entities;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer.Interfaces
{
    public interface IUserService// : IGenericService<User>
    {
        Task<TView> CreateAsync<TCreate, TView>(ViewModels.Users.Create createView)
            where TCreate : ICreateView<User>
            where TView : IViewOf<User>;
    }
}
