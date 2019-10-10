using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.InMemoryControllerTests.TestServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, ViewModel.User.List>();
                cfg.CreateMap<User, ViewModel.User.Detailed>();
            }));
        }

        public async Task<TView> CreateAsync<TView>(ViewModel.User.Create toCreate)
        {
            if (toCreate == null)
                throw new ArgumentNullException(nameof(toCreate));

            var newUser = new User
            {
                Username = toCreate.Username,
                Password = toCreate.Password,
                Email = toCreate.Email
            };

            return await Task.FromResult(_mapper.Map<TView>(newUser));
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>()
        {
            var list = new List<User>
            {
            };

            return await Task.FromResult<IEnumerable<TView>>(_mapper.ProjectTo<TView>(list.AsQueryable()).ToArray());
        }

        public async Task<TView> GetByIdAsync<TView>(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await Task.FromResult(_mapper.Map<TView>(new User { }));
        }

        public async Task<TView> UpdateAsync<TView>(int id, ViewModel.User.Update toUpdate)
        {
            if (toUpdate == null)
                throw new ArgumentNullException(nameof(toUpdate));

            var updatedUser = new User
            {
                Username = toUpdate.Username,
                Password = toUpdate.Password,
                Email = toUpdate.Email
            };

            return await Task.FromResult(_mapper.Map<TView>(updatedUser));
        }
    }
}
