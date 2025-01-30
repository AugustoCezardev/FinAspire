using System.Security.Claims;
using FinAspire.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace FinAspire.API.Endpoints.Identity;

public abstract class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) 
        => routeBuilder.MapGet("/roles", HandleAsync);

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
        {
            Results.Unauthorized();
        }

        var identity = (ClaimsIdentity)user.Identity!;

        var roles = identity?
            .FindAll(identity.RoleClaimType)
            .Select(c => new
            {
                c.Issuer,
                c.OriginalIssuer,
                c.Type,
                c.Value,
                c.ValueType
            });

        return TypedResults.Json(roles);
    }
}