using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Service.Services
{
  public class WalletService: BaseService<Wallet>, IWalletService
  {
    public WalletService(IWalletRepository repository) : base(repository) { }

    public async Task<WalletDto> ReadHistory(long idInvestor)
    {
      var query = """
        SELECT * FROM Wallet

        JOIN FinancialMovement
        ON FinancialMovement.IdWallet = Wallet.Id

        JOIN FinancialMovementType
        ON FinancialMovementType.Id = FinancialMovement.IdFinancialMovementType

        WHERE Wallet.IdInvestor = @IdInvestor
      """;

      var history = await repository.RunQuery<WalletHistoryDto>(query, new { IdInvestor = idInvestor });


      return new WalletDto() {
        History = history,
      };
    }
  }
}
