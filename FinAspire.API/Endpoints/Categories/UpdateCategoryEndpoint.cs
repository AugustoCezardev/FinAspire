﻿using System.Security.Claims;
using FinAspire.API.Common;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;

namespace FinAspire.API.Endpoints.Categories;

public abstract class UpdateCategoryEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder)
        => routeBuilder.MapPut("/", HandleAsync)
            .WithDescription("Categories: Update")
            .WithSummary("Update category")
            .WithOrder(3)
            .Produces<BaseResponse<Category>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        UpdateCategoryRequest request 
        )
    {
        request.UserId = user.Identity?.Name ?? String.Empty;
        var response = await handler.UpdateAsync(request);
        return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
    }
}