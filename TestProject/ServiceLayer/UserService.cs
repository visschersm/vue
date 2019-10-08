using DataLayer;
using DbModel;

namespace ServiceLayer
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(IContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public ViewLayer.User.List Create(ViewLayer.User.Create user)
        {
            var newUser = _userRepository.Create(new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Username = user.Username,
                Password = user.Password
            });

            return new ViewLayer.User.List
            {
                Id = newUser.Id,
                Username = newUser.Username
            };
        }
    }
}
