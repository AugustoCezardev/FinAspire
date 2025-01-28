using FinAspire.API.Endpoints;
using FinAspire.API.Handlers;
using FinAspire.Core.Handler;
using FinAspire.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ImplementPersistence(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(schemaType => schemaType.FullName);
});

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.Run();

