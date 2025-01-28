using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) 
        => routeBuilder.MapGet("/{id:long}", HandleAsync)
            .WithName("Transactions: GetByPeriod")
            .WithSummary("Get transactions by period")
            .WithDescription("Get transactions by period")
            .Produces<BaseResponse<List<Transaction>?>>();

    private static Task<IResult> HandleAsync(long id, DateTime startDate, DateTime endDate, ITransactionHandler handler)
    {
        throw new NotImplementedException();
    }
}