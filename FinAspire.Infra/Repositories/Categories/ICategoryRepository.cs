using FinAspire.Core.Models;

namespace FinAspire.Infra.Repositories.Categories;

public interface ICategoryRepository
{
    Task<IList<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(long id);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<Category> DeleteAsync(long id);
}