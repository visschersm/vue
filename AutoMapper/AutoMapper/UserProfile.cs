using AutoMapper;
using AutoMapperTest.Models;
using AutoMapperTest.ViewModel;

namespace AutoMapperTest
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
