using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;
using FinAspire.Infra.Repositories.Categories;

namespace FinAspire.API.Handlers;

public class CategoryHandler(ICategoryRepository repository): ICategoryHandler
{
    public async Task<BaseResponse<Category>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                Title = request.Title,
                Description = request.Description,
            };

            await repository.CreateAsync(category);

            return new BaseResponse<Category>(category, message: "Category created successfully", code: 201);
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>(code: 500, message: e.Message, data: null);
        }
    }

    public Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        throw new NotImplementedException();
    }
}