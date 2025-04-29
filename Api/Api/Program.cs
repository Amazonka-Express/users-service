using Api.Extensions;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.ConfigureDbContext();
builder.Services.ConfigureLogger(builder.Configuration);
builder.Services.ConfigureExceptionMiddleware();
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
