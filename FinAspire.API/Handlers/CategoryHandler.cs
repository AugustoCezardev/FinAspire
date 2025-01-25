using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;
using FinAspire.Infra.Repositories.Categories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                Id = request.Id,
                Title = request.Title ?? String.Empty,
                Description = request.Description,
            };
            var result = await repository.UpdateAsync(category);
            return new BaseResponse<Category>(result, message: "Category updated successfully", code: 200);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var result = await repository.DeleteAsync(request.Id);
            
            return new BaseResponse<Category>(result, message: "Category deleted successfully", code: 200);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse<Category>(code: 500, message: e.Message, data: null);
        }
    }

    public async Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var result = await repository.GetByIdAsync(request.Id);
            
            return result == null ? new BaseResponse<Category>(code: 204, message: "Category not found", data: null) 
                : new BaseResponse<Category>(result, message: "Category found", code: 200);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<BaseResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var result = await repository.GetAllAsync();
            
            return new BaseResponse<List<Category>>(result.ToList(), message: "Categories found", code: 200);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}