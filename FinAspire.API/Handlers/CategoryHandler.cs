using System.Text;
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
                UserId = request.UserId
            };

            await repository.CreateAsync(category);

            return new BaseResponse<Category>(category, message: "Category created successfully", code: 201);
        }
        catch (Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("[CAT003] ");
            sb.Append(e.Message);
            return new BaseResponse<Category>(code: 500, message: sb.ToString(), data: null);
        }
    }

    public async Task<BaseResponse<Category>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await repository.GetByIdAsync(request.Id, request.UserId);

            if (category == null)
            {
                Console.WriteLine("[CAT001] Category not found");
                return new BaseResponse<Category>(code: 204, message: "[CAT001] Category not found", data: null);
            }
            
            category.Title = request.Title;
            category.Description = request.Description;
            
            var result = await repository.UpdateAsync(category);
            return new BaseResponse<Category>(result, message: "Category updated successfully", code: 200);
        }
        catch (Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("[CAT002] ");
            sb.Append(e.Message);
            return new BaseResponse<Category>(code: 500, message: sb.ToString(), data: null);
        }
    }

    public async Task<BaseResponse<Category>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await repository.GetByIdAsync(request.Id, request.UserId);
            
            if (category == null) 
                return new BaseResponse<Category>(code: 204, message: "[CAT003] Category not found", data: null);
            
            var result = await repository.DeleteAsync(request.Id);
            
            return new BaseResponse<Category>(result, message: "Category deleted successfully", code: 200);
            
        }
        catch (Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("[CAT004] ");
            sb.Append(e.Message);
            return new BaseResponse<Category>(code: 500, message: sb.ToString(), data: null);
        }
    }

    public async Task<BaseResponse<Category>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var result = await repository.GetByIdAsync(request.Id, request.UserId);
            
            return result == null ? new BaseResponse<Category>(code: 204, message: "Category not found", data: null) 
                : new BaseResponse<Category>(result, message: "Category found", code: 200);
        }
        catch (Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("[CAT005] ");
            sb.Append(e.Message);
            return new BaseResponse<Category>(code: 500, message: sb.ToString(), data: null);
        }
    }

    //TODO Rever esse metodo, não esta fazendo muito sentido trafegar o request
    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var result = await repository.GetAllAsync(request);
            result.Message = "All categories found";
            
            return result;
        }
        catch (Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("[CAT006] ");
            sb.Append(e.Message);
            return new PagedResponse<List<Category>?>(code: 500, message: sb.ToString(), data: null);
        }
    }
}