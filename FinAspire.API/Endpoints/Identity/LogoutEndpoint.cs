using FinAspire.API.Common;
using FinAspire.Infra.Models;
using Microsoft.AspNetCore.Identity;

namespace FinAspire.API.Endpoints.Identity;

public abstract class LogoutEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder routeBuilder) 
        => routeBuilder.MapPost("/logout", HandleAsync)
            .Produces<IResult>();

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}