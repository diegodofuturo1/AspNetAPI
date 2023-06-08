using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {

        Task<User> GetByEmailAsync(string email);
        Task<IList<User>> SearchByEmailAsync(string email);
        Task<IList<User>> SearchByNameAsync(string name);
    }
}
