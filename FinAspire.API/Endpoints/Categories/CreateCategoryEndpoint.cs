using System.Reflection.Metadata;
using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Categories;

public abstract class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) =>
        routeBuilder.MapPost("/", HandleAsync)
            .WithName("Categories: Create category")
            .WithSummary("Create category")
            .Produces<BaseResponse<Category>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        var result = await handler.CreateAsync(request);
        
        return result.IsSuccess ? 
            TypedResults.Created($"/{result.Data?.Id}", result.Data) : 
            TypedResults.BadRequest(result);
    }

}