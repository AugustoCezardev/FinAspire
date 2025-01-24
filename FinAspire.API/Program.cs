using FinAspire.API.Handlers;
using FinAspire.Core.Handler;
using FinAspire.Core.Models;
using FinAspire.Core.Request.Categories;
using FinAspire.Core.Response;
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

app.MapPost("/v1/Categories", 
    (CreateCategoryRequest body, ICategoryHandler handler) => handler.CreateAsync(body))
    .WithName("Categories: Create")
    .WithSummary("Create a new category")
    .Produces<BaseResponse<Category>>();

app.Run();

