using FinAspire.API.Common;
using FinAspire.API.Endpoints.Categories;

namespace FinAspire.API.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpointsMap = app.MapGroup("");

        endpointsMap.MapGroup("v1/categories")
            .WithTags("Categories")
            .MapEndpoints<CreateCategoryEndpoint>()
            .MapEndpoints<GetCategoryByIdEndpoint>()
            .MapEndpoints<GetAllCategoriesEndpoint>()
            .MapEndpoints<DeleteCategoryEndpoint>()
            .MapEndpoints<UpdateCategoryEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoints<TEndpoint>(this IEndpointRouteBuilder endpoints)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(endpoints);
        return endpoints;
    }
}