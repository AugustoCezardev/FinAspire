using System.Security.Claims;
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
            .WithOrder(3)
            .Produces<BaseResponse<Transaction>>();
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        UpdateTransactioRequest request,
        ITransactionHandler handler)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var response = await handler.UpdateAsync(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}