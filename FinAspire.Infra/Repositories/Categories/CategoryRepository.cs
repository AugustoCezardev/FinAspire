using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;
using FinAspire.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinAspire.Infra.Repositories.Categories;

public class CategoryRepository(AppDbContext dbContext): ICategoryRepository
{
    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {

            var query = dbContext.Categories
                .AsNoTracking()
                .Where(c => c.UserId == request.UserId);
            
            var categories = await query
                .Skip(request.PageSize * (request.Page - 1))
                .Take(request.PageSize)
                .ToListAsync();
            
            var count = await query.CountAsync();
            
            return new PagedResponse<List<Category>?>(categories, count, request.Page);
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Category?> GetByIdAsync(long id, string userId)
    {
        try
        {
            var category = await dbContext.Categories.
                FirstOrDefaultAsync(x => x.Id == id 
                                         && x.UserId == userId);
            
            return category;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
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

    public async Task<Category> UpdateAsync(Category category)
    {
        try
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Category> DeleteAsync(long id)
    {
        try
        {
            var category = new Category { Id = id };
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}