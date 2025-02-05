using FinAspire.API.Handlers;
using FinAspire.Core;
using FinAspire.Core.Handler;
using FinAspire.Infra;
using FinAspire.Infra.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace FinAspire.API.Common;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder
            .Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        
        Configuration.BackEndUrl = builder.Configuration["BackEndUrl"] ?? string.Empty;
        Configuration.FrontEndUrl = builder.Configuration["FrontEndUrl"] ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(schemaType => schemaType.FullName);
        });
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddCookie();
        builder.Services.AddAuthorization();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services
            .ImplementPersistence(builder.Configuration);

        builder.Services.AddIdentityApiEndpoints<User>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
        builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options =>
            {
                options.AddPolicy(
                    APIConfiguration.CorsPolicyName,
                    policy
                        => policy.WithOrigins([
                                Configuration.BackEndUrl,
                                Configuration.FrontEndUrl
                            ])
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
            });
    }
}