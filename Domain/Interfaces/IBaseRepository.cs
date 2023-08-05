using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T: Base {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> DeleteAsync(T obj);
        Task<List<T>> SelectAllAsync();
        Task<T> SelectAsync(long id);
        Task<T> SelectAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);

    }

    public interface IBuilderRepository : IBaseRepository<Builder>
    {

    }

    public interface IContributionRepository : IBaseRepository<Contribution>
    {

    }

    public interface IEnterpriseRepository : IBaseRepository<Enterprise>
    {

    }

    public interface IInvestorRepository : IBaseRepository<Investor>
    {

    }

    public interface IRevenueRepository : IBaseRepository<Revenue>
    {

    }

    public interface IWalletRepository : IBaseRepository<Wallet>
    {

    }
}
