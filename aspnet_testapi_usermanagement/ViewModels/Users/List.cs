using DataLayer.Entities.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Users
{
    public class List : IViewOf<User>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
