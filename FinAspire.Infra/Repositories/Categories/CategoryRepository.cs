using FinAspire.Core.Models;
using FinAspire.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinAspire.Infra.Repositories.Categories;

public class CategoryRepository(AppDbContext dbContext): ICategoryRepository
{
    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> CreateAsync(Category category)
    {
        try
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
}