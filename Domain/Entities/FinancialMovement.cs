using System;

namespace Domain.Entities
{
  public class FinancialMovement: Base
  {
    public int IdWallet { get; set; }
    public int IdFinancialMovementType { get; set; }
    public decimal Value { get; set; }
    public DateTime MovementDate { get; set; }
  }
}
