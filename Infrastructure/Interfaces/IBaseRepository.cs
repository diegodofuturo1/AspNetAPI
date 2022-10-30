using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T: Base {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);

    }
}
