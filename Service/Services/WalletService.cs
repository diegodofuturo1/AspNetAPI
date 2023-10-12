using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
  public class WalletService: BaseService<Wallet>, IWalletService
  {
    private readonly IFinancialMovementRepository FinancialMovementRepository;

    public WalletService(
      IWalletRepository repository,
      IFinancialMovementRepository _financialMovementRepository
    ) : base(repository) {
      FinancialMovementRepository = _financialMovementRepository;
    }

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

    private async Task<FinancialMovement> InsertFinancialMovement(int idWallet, short idType, decimal value)
    {
      return await FinancialMovementRepository.InsertAsync(new FinancialMovement()
      {
        Active= true,
        IdFinancialMovementType= idType,
        Value = value,
        MovementDate = DateTime.Now,
        IdWallet = idWallet
      });
    }

    public async Task<WalletDto> Deposit(int idWallet, decimal value)
    {
      await InsertFinancialMovement(idWallet, 1, value);

      return await ReadHistory(idWallet);
    }

    public async Task<WalletDto> Retreat(int idWallet, decimal value)
    {
      await InsertFinancialMovement(idWallet, 2, value);

      return await ReadHistory(idWallet);
    }
  }
}
