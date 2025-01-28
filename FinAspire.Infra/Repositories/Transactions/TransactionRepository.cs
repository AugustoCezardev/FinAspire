using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;
using FinAspire.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinAspire.Infra.Repositories.Transactions;

public class TransactionRepository(AppDbContext dbContext): ITransactionRepository
{
    public async Task<Transaction?> GetByIdAsync(long id, string userId)
    {
        try
        {
            var transaction = await dbContext.
                Transactions.
                AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == id 
                                         && x.UserId == userId);
            
            return transaction;
            
        }catch(DbUpdateException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        try
        {
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
            return transaction;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        try
        {
            dbContext.Transactions.Update(transaction);
            await dbContext.SaveChangesAsync();
            return transaction;
            
        }catch(DbUpdateException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<Transaction> DeleteAsync(Transaction transaction)
    {
        try
        {
            dbContext.Transactions.Remove(transaction);
            await dbContext.SaveChangesAsync();
            return transaction;
        }catch(DbUpdateException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}