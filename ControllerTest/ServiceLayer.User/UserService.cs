using AutoMapper;
using DataLayer.Database;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IDataModel _context;
        private readonly IMapper _mapper;

        public UserService(IDataModel context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            var createdUser = _context.Users.Add(newUser).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<TView>(createdUser);
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>()
        {
            var query = _context.Users.AsNoTracking();
            return await _mapper.ProjectTo<TView>(query).ToArrayAsync();
        }

        public async Task<TView> GetByIdAsync<TView>(int id)
        {
            var query = _context.Users.AsNoTracking()
                .Where(x => x.Id == id);

            return await _mapper.ProjectTo<TView>(query).SingleOrDefaultAsync();
        }

        public async Task<TView> UpdateAsync<TView>(int id, ViewModel.User.Update toUpdate)
        {
            var user = await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (user == null)
                return default;

            user.Username = toUpdate.Username;
            user.Password = toUpdate.Password;
            user.Email = toUpdate.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<TView>(user);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id));

            var toDelete = await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (toDelete == null)
                return false;

            _context.Users.Remove(toDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
