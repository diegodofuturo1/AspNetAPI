using System;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Contexts;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository()
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            Expression<Func<User, bool>> filter = user => user.Email.ToLower() == email.ToLower();

            return await SelectAsync(filter);
        }

        public async Task<IList<User>> SearchByEmailAsync(string email)
        {
            Expression<Func<User, bool>> filter = user => user.Email.ToLower().Contains(email.ToLower());

            return await SearchAsync(filter);
        }

        public async Task<IList<User>> SearchByNameAsync(string name)
        {
            Expression<Func<User, bool>> filter = user => user.Name.ToLower().Contains(name.ToLower());

            return await SearchAsync(filter);
        }
    }
}
