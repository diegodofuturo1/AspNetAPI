using System;

namespace Service.Dtos
{
  public class WalletHistoryDto
  {
    public long IdWallet { get; set; }
    public long IdInvestor { get; set; }
    public long IdFinancialMovementType { get; set; }
    public bool Active { get; set; }
    public decimal Value { get; set; }
    public DateTime MovementDate { get; set; }
    public string Description { get; set; }
  }
}
