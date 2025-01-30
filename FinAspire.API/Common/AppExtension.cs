using System.Security.Claims;
using FinAspire.Infra.Models;
using Microsoft.AspNetCore.Identity;

namespace FinAspire.API.Common;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapSwagger().RequireAuthorization();
    }
    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
    
}