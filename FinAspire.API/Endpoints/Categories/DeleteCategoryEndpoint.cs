using System.Security.Claims;
using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Categories;

public abstract class DeleteCategoryEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapDelete("/{id:long}", HandleAsync)
            .WithDescription("Categories: DeleteCategory")
            .WithSummary("Delete category by id")
            .WithOrder(2)
            .Produces<BaseResponse<Category>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        long id)
    {
        var request = new DeleteCategoryRequest { Id = id, UserId = user.Identity?.Name ?? string.Empty};
        var response = await handler.DeleteAsync(request);
        
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}