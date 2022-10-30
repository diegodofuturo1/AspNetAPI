using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext context): base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            Expression<Func<User, bool>> filter = user => user.Email.ToLower() == email.ToLower();

            return await GetAsync(filter);
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
