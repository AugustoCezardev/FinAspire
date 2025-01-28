using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Categories;

public abstract class GetCategoryByIdEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapGet("/{id:long}", HandleAsync)
            .WithDescription("Categories: GetById")
            .WithSummary("Get one category by id")
            .Produces<BaseResponse<Category>>();

    private static async Task<IResult> HandleAsync(long id, string userId, ICategoryHandler handler)
    {
        var request = new GetCategoryByIdRequest { Id = id, UserId = userId};
        var response = await handler.GetByIdAsync(request);
        
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}