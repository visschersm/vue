using AutoMapper;
using DataLayer.Entities;
using DataLayer.Entities.Entities;

namespace ViewModels.Users
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<ViewModels.Users.Create, ApplicationUser>();
            CreateMap<ViewModels.Users.Create, User>();
            CreateMap<User, ViewModels.Users.Simple>();
        }
    }
}
