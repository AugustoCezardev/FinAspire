﻿using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class DeleteTransactionEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapDelete("/{id:long}", HandleAsync)
            .WithName("Transactions: Delete")
            .WithDescription("Delete transaction by id")
            .WithSummary("Delete transaction by id")
            .Produces<BaseResponse<Transaction>>();

    private static async Task<IResult> HandleAsync(long id, string userId, ITransactionHandler handler)
    {
        var request = new DeleteTransactionRequest { Id = id, UserId = userId};
        var response = await handler.DeleteAsync(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}