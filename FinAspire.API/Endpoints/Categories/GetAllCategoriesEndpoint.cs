using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Categories;

public abstract class GetAllCategoriesEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapGet("/", HandleAsync)
            .WithDescription("Categories: GetAll")
            .WithSummary("Get all user categories")
            .WithOrder(3)
            .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(string userId, int page, ICategoryHandler handler)
    {
        var request = new GetAllCategoriesRequest { UserId = userId, Page = page};
        var response = await handler.GetAllAsync(request);
        
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}