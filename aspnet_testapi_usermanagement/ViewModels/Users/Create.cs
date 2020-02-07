using DataLayer.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Users
{
    public class Create : ICreateView<User>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
