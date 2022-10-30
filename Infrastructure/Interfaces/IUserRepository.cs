using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {

        Task<User> GetByEmailAsync(string email);
        Task<IList<User>> SearchByEmailAsync(string email);
        Task<IList<User>> SearchByNameAsync(string name);
    }
}
