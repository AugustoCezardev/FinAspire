using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class UpdateTransactionEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapPut("/", HandleAsync)
            .WithName("Transactions: Update")
            .WithSummary("Update transaction")
            .WithDescription("Update transaction")
            .Produces<BaseResponse<Transaction>>();
    
    private static async Task<IResult> HandleAsync(UpdateTransactioRequest request, ITransactionHandler handler)
    {
        var response = await handler.UpdateAsync(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}