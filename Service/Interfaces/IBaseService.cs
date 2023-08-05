using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBaseService<T> where T : Base, new()
    {
        public Task<T> Create(T entity);
        public Task<IList<T>> ReadAll();
        public Task<T> ReadById(long id);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
    }

    public interface IBuilderService : IBaseService<Builder>
    {
    }

    public interface IContributionService : IBaseService<Contribution>
    {
    }

    public interface IEnterpriseService : IBaseService<Enterprise>
    {
    }

    public interface IInvestorService : IBaseService<Investor>
    {
    }

    public interface IRevenueService : IBaseService<Revenue>
    {
    }

    public interface IWalletService : IBaseService<Wallet>
    {
    }
}
