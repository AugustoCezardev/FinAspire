using FinAspire.API.Common;
using FinAspire.API.Endpoints.Categories;
using FinAspire.API.Endpoints.Identity;
using FinAspire.API.Endpoints.Transactions;
using FinAspire.Infra.Models;

namespace FinAspire.API.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpointsMap = app
            .MapGroup("");
        
        endpointsMap
            .MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "Healthy" });
        
        endpointsMap.MapGroup("v1/auth")
            .WithTags("Auth")
            .MapIdentityApi<User>();

        endpointsMap.MapGroup("v1/auth")
            .WithTags("Auth")
            .MapEndpoints<LogoutEndpoint>()
            .MapEndpoints<GetRolesEndpoint>();

        endpointsMap.MapGroup("v1/categories")
            .WithTags("Categories")
            .RequireAuthorization()
            .MapEndpoints<CreateCategoryEndpoint>()
            .MapEndpoints<GetCategoryByIdEndpoint>()
            .MapEndpoints<GetAllCategoriesEndpoint>()
            .MapEndpoints<DeleteCategoryEndpoint>()
            .MapEndpoints<UpdateCategoryEndpoint>();

        endpointsMap.MapGroup("v1/transactions")
            .WithTags("Transactions")
            .RequireAuthorization()
            .MapEndpoints<CreateTransactionEndpoint>()
            .MapEndpoints<UpdateTransactionEndpoint>()
            .MapEndpoints<GetTransactionsByPeriodEndpoint>()
            .MapEndpoints<GetTransactionByIdEndpoint>()
            .MapEndpoints<DeleteTransactionEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoints<TEndpoint>(this IEndpointRouteBuilder endpoints)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(endpoints);
        return endpoints;
    }
}