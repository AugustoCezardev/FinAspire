using System.Reflection.Metadata;
using System.Security.Claims;
using Azure.Core;
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
            .WithOrder(1)
            .Produces<BaseResponse<Category>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.CreateAsync(request);
        
        return result.IsSuccess ? 
            TypedResults.Created($"/{result.Data?.Id}", result.Data) : 
            TypedResults.BadRequest(result);
    }

}