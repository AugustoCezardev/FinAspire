using FinAspire.Core.Common.Extensions;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;
using FinAspire.Infra.Repositories.Transactions;

namespace FinAspire.API.Handlers;

public class TransactionHandler(ITransactionRepository repository): ITransactionHandler
{
    public async Task<BaseResponse<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        try
        {
            var transaction = new Transaction
            {
                Title = request.Title,
                UserId = request.UserId,
                Amount = request.Amount,
                Type = request.Type,
                CreatedAt = DateTime.Now,
                CategoryId = request.CategoryId,
                PaidOrReceivedAt = request.PaidOrReceivedAt
            };
            
            transaction = await repository.CreateAsync(transaction);
            
            return new BaseResponse<Transaction?>(transaction, message: "Transaction created successfully",
                code: 201);
            
        }catch(Exception ex)
        {
            return new BaseResponse<Transaction?>(code: 500, message: ex.Message, data: null);
        }
    }

    public async Task<BaseResponse<Transaction?>> UpdateAsync(UpdateTransactioRequest request)
    {
        try
        {
            var transaction = await repository.GetByIdAsync(request.Id, request.UserId);
            
            if (transaction is null)
            {
                return new BaseResponse<Transaction?>(code: 404, message: "Transaction not found", data: null);
            }
            
            transaction.Title = request.Title;
            transaction.Amount = request.Amount;
            transaction.Type = request.Type;
            transaction.CategoryId = request.CategoryId;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
            
            var result = await repository.UpdateAsync(transaction);
            
            return new BaseResponse<Transaction?>(result, message: "Transaction updated successfully", code: 200);
            
        }catch(Exception ex)
        {
            return new BaseResponse<Transaction?>(code: 500, message: ex.Message, data: null);    
        }
        
        
    }

    public async Task<BaseResponse<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await repository.GetByIdAsync(request.Id, request.UserId);
            
            if (transaction is null)
            {
                return new BaseResponse<Transaction?>(code: 404, message: "Transaction not found", data: null);
            }
            
            var result = await repository.DeleteAsync(transaction);
            
            return new BaseResponse<Transaction?>(result, message: "Transaction deleted successfully", code: 200);
            
        }catch(Exception ex)
        {
            return new BaseResponse<Transaction?>(code: 500, message: ex.Message, data: null);
        }
    }

    public async Task<BaseResponse<Transaction?>> GetById(GetTransactionByIdRequest request)
    {
        try
        {
            var transaction = await repository.GetByIdAsync(request.Id, request.UserId);
            
            return transaction is null ? 
                new BaseResponse<Transaction?>(code: 404, message: "Transaction not found", data: null) : 
                new BaseResponse<Transaction?>(transaction, message: "Transaction found successfully", code: 200);
            
        }catch(Exception ex)
        {
            return new BaseResponse<Transaction?>(code: 500, message: ex.Message, data: null);   
        }
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriod(GetTransactionByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirtsDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
            
            var result = await repository.GetByPeriodAsync(request);
            
            return result;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new PagedResponse<List<Transaction>?>(code: 500, message: e.Message, data: null);
        }
    }
}