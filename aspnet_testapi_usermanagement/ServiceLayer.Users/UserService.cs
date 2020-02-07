using AutoMapper;
using DataLayer.Entities;
using DataLayer.Entities.Entities;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer.Users
{
    public class UserService : BaseService<int, User>, IUserService
    {
        private readonly ApplicationUserManager _userManager;

        public UserService(ApplicationUserManager userManager, IDataContext context, IMapper mapper)
            : base(context, mapper)
        {
            _userManager = userManager;
        }

        public async Task<TView> CreateAsync<TCreate, TView>(ViewModels.Users.Create createView)
            where TCreate : ICreateView<User>
            where TView : IViewOf<User>
        {
            var toCreate = _mapper.Map<User>(createView);
            var newUser = _repository.Add(toCreate).Entity;
            var appUser = _mapper.Map<ApplicationUser>(createView);
            var result = await _userManager.CreateAsync(appUser, createView.Password);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
            }

            var createdUser = _mapper.Map<TView>(newUser);

            return createdUser;
        }
    }
}
