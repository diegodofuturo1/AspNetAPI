using Domain.Dtos;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        Task<WalletDto> ReadHistory(long idInvestor);
        Task<WalletDto> Deposit(int idWallet, decimal value);
        Task<WalletDto> Retreat(int idWallet, decimal value);
    }
}
