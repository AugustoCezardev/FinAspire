using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FinAspire.Web;
using MudBlazor.Services;
using FinAspire.Web.Security;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CookieHandler>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient(Configuration.HttpClientName, options =>
{
    options.BaseAddress = new Uri(Configuration.BackEndUrl);
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();