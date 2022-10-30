using System;
using System.Linq;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T: Base
    {
        protected readonly UserContext context;

        public BaseRepository(UserContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task RemoveAsync(long id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                context.Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await context.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true)
            => asNoTracking
                ? await BuildQuery(expression).AsNoTracking().FirstOrDefaultAsync()
                : await BuildQuery(expression).FirstOrDefaultAsync();

        public virtual async Task<IList<T>> SearchAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true)
            => asNoTracking 
                ? await BuildQuery(expression).AsNoTracking().ToListAsync()
                : await BuildQuery(expression).ToListAsync();

        private IQueryable<T> BuildQuery(Expression<Func<T, bool>> expression) => context.Set<T>().Where(expression);
    }
}
