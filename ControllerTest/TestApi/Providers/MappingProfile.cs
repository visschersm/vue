using AutoMapper;
using DataLayer.Entities;

namespace TestApi.Providers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ViewModel.User.List>();

            CreateMap<User, ViewModel.User.Detailed>();
        }
    }
}
