﻿using System.Security.Claims;
using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Transactions;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Transactions;

public abstract class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) 
        => routeBuilder.MapGet("/{id:long}", HandleAsync)
            .WithName("Transactions: GetById")
            .WithSummary("Get one transaction by id")
            .WithDescription("Get one transaction by id")
            .WithOrder(4)
            .Produces<BaseResponse<Transaction>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        long id
        )
    {
        var request = new GetTransactionByIdRequest {Id = id, UserId = user.Identity?.Name ?? string.Empty};
        var response = await handler.GetById(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}