using AutoMapper;
using DataLayer.Entities;
using DataLayer.Entities.Entities;

namespace ViewModels.Users
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<ViewModels.Users.Create, User>();
            CreateMap<ViewModels.Users.Create, ApplicationUser>();
            CreateMap<User, ViewModels.Users.Simple>();
            CreateMap<ApplicationUser, ViewModels.Users.Simple>();
            CreateMap<User, ViewModels.Users.List>();
            CreateMap<ApplicationUser, ViewModels.Users.List>();
            CreateMap<ViewModels.Users.Update, User>();
            CreateMap<ViewModels.Users.Update, ApplicationUser>();
        }
    }
}
