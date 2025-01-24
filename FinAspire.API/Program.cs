var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/v1/Transaction", 
        (Request body, Handler handler) => handler.Handle(body))
    .WithName("Transaction: Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();


app.MapPut("/v1/Transaction", 
    (Request body, Handler handler) => handler.Handle(body))
    .WithName("Transaction: Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();


app.Run();

public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; } = 2;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

public class Response(string message);

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response("Hello World!");
    }
}