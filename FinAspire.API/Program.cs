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

app.MapGet("/v1/Categories/{id:long}", 
        ( long id, ICategoryHandler handler) => handler.GetByIdAsync(new GetCategoryByIdRequest { Id = id }))
    .WithName("Categories: GetById")
    .WithSummary("Get one category by id")
    .Produces<BaseResponse<Category>>();

app.MapGet("/v1/Categories", 
        ( ICategoryHandler handler) => handler.GetAllAsync(new GetAllCategoriesRequest {Page = 1, PageSize = 10, UserId = "1"}))
    .WithName("Categories: GetAll")
    .WithSummary("Get all categories")
    .Produces<BaseResponse<Category>>();

app.MapPut("/v1/Categories", 
        ( UpdateCategoryRequest body, ICategoryHandler handler) => handler.UpdateAsync(body))
    .WithName("Categories: Update")
    .WithSummary("Update category")
    .Produces<BaseResponse<Category>>();

app.MapDelete("/v1/Categories/{id:long}", 
        ( long id, ICategoryHandler handler) => handler.DeleteAsync(new DeleteCategoryRequest { Id = id }))
    .WithName("Categories: Delete")
    .WithSummary("Remove category")
    .Produces<BaseResponse<Category>>();

app.Run();

