using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FinAspire_API>("API")
    .WithExternalHttpEndpoints();

builder.Build().Run();
