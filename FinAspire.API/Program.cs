using FinAspire.Core.Models;
using FinAspire.Infra;
using FinAspire.Infra.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddTransient<Handler>();

builder.Services.ImplementPersistence(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/v1/Categories", 
    (Request body, Handler handler) => handler.Handle(body))
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response>();

app.Run();

public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class Response(long id, string title);

public class Handler(AppDbContext dbContext)
{
    public Response Handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description,
        };
        
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
        
        return new Response(category.Id, category.Title);
    }
}