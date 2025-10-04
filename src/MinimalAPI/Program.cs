using FluentValidation;
using Infrastructure;
using MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IRandomProductRepository, RandomProductRepository>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

// Register validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Map endpoints
app.MapProducts();
app.MapCustomers();
app.MapOrders();

app.Run();
