using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class  CreateTransactionEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapPost("/", HandleAsync)
            .WithName("Transactions: Create transaction")
            .WithSummary("Create transaction")
            .WithDescription("Create transaction")
            .WithOrder(1)
            .Produces<BaseResponse<Transaction>>();

    private static async Task<IResult> HandleAsync(CreateTransactionRequest request, ITransactionHandler handler)
    {
        var response = await handler.CreateAsync(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}