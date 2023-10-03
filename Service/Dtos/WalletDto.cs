using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Dtos
{
  public class WalletDto: Wallet
  {
    public List<WalletHistoryDto> History { get; set; }
    public decimal AccountBalance => Deposits + Payments - Removals - Contributions;
    public decimal TotalBalance => Deposits + Payments - Removals;

    public decimal Deposits => History.Where(x => x.IdFinancialMovementType == 1).Sum(x => x.Value);
    public decimal Removals => History.Where(x => x.IdFinancialMovementType == 2).Sum(x => x.Value);
    public decimal Contributions => History.Where(x => x.IdFinancialMovementType == 3).Sum(x => x.Value);
    public decimal Payments => History.Where(x => x.IdFinancialMovementType == 4).Sum(x => x.Value);
  }
}
