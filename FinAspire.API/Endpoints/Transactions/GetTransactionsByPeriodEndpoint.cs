using FinAspire.API.Common;
using FinAspire.Core;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) 
        => routeBuilder.MapGet("/", HandleAsync)
            .WithName("Transactions: GetByPeriod")
            .WithSummary("Get transactions by period")
            .WithDescription("Get transactions by period")
            .WithOrder(5)
            .Produces<BaseResponse<List<Transaction>?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, 
        DateTime? startDate = null, 
        DateTime? endDate = null,
        int page = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTransactionByPeriodRequest
        {
            UserId = "Augusto@Teste",
            StartDate = startDate,
            EndDate = endDate,
            Page = page,
            PageSize = pageSize
        };
        
        var response = await handler.GetByPeriod(request);
        
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}