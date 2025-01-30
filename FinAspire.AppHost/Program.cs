using Microsoft.Extensions.DependencyInjection;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<FinAspire_API>("API")
    .WithExternalHttpEndpoints();


builder.Build().Run();
