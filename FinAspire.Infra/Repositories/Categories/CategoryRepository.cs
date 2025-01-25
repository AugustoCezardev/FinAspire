using FinAspire.Core.Models;
using FinAspire.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FinAspire.Infra.Repositories.Categories;

public class CategoryRepository(AppDbContext dbContext): ICategoryRepository
{
    public async Task<IList<Category>> GetAllAsync()
    {
        try
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories.ToList();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        try
        {
            var category = await dbContext.Categories.FindAsync(id);
            
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