using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : Base, new()
    {
        protected readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }
        async Task<T> IBaseService<T>.Create(T entity)
        {
            return await repository.InsertAsync(entity);
        }

        async Task<T> IBaseService<T>.Delete(T entity)
        {
            return await repository.DeleteAsync(entity);
        }

        async Task<IList<T>> IBaseService<T>.ReadAll()
        {
            return await repository.SelectAllAsync();
        }

        async Task<T> IBaseService<T>.ReadById(long id)
        {
            return await repository.SelectAsync(id);
        }

        async Task<T> IBaseService<T>.Update(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }

    public class BuilderService : BaseService<Builder>, IBuilderService
    {
        public BuilderService(IBuilderRepository repository) : base(repository) { }
    }

    public class ContributionService : BaseService<Contribution>, IContributionService
    {
        public ContributionService(IContributionRepository repository) : base(repository) { }
    }

    public class EnterpriseService : BaseService<Enterprise>, IEnterpriseService
    {
        public EnterpriseService(IEnterpriseRepository repository) : base(repository) { }
    }

    public class InvestorService : BaseService<Investor>, IInvestorService
    {
        public InvestorService(IInvestorRepository repository) : base(repository) { }
    }

    public class RevenueService : BaseService<Revenue>, IRevenueService
    {
        public RevenueService(IRevenueRepository repository) : base(repository) { }
    }
}
