using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.Infra.Repositories.Categories;

public interface ICategoryRepository
{
    Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request);
    Task<Category?> GetByIdAsync(long id, string userId);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<Category> DeleteAsync(long id);
}