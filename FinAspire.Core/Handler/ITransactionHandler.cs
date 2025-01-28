using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.Core.Handler;

public interface ITransactionHandler
{
    Task<BaseResponse<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactioRequest request);
    Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
    Task<BaseResponse<Transaction?>> GetById(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>?>> GetByPeriod(GetTransactionByPeriodRequest request);
}