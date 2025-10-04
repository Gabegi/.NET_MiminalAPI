using Infrastructure;
using MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IRandomProductRepository, RandomProductRepository>();

var app = builder.Build();

// Map endpoints
app.MapProducts();

app.Run();
