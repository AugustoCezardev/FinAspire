using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.Core.Handler;

public interface ICategoryHandler
{
    Task<BaseResponse<Category>> CreateAsync(CreateCategoryRequest request);
    Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequest request);
    Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request);
    Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request);
}