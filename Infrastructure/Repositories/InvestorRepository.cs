using System;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Contexts;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class InvestorRepository : BaseRepository<Investor>, IInvestorRepository
    {
        public InvestorRepository()
        {
        }
    }
}
