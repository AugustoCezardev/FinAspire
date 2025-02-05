using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.Infra.Repositories.Transactions;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(long id, string userId);
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task<Transaction> DeleteAsync(Transaction transaction);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodRequest request);
}