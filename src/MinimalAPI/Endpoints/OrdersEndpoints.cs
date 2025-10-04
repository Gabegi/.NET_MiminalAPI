using EShop.Core.Entities;
using Infrastructure;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Requests;

namespace MinimalAPI.Endpoints;

public static class OrdersEndpoints
{
    public static void MapOrders(this WebApplication app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("/", (IOrderRepository orderRepo) => orderRepo.GetAll());

        group.MapGet("/{id}", (int id, IOrderRepository orderRepo) =>
        {
            var order = orderRepo.GetById(id);
            return order is not null ? Results.Ok(order) : Results.NotFound();
        });

        group.MapGet("/customer/{customerId}", (int customerId, IOrderRepository orderRepo) =>
            orderRepo.GetByCustomerId(customerId));

        group.MapPost("/", (CreateOrderRequest request, IOrderRepository orderRepo) =>
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                Items = request.Items
            };
            var created = orderRepo.Add(order);
            return Results.Created($"/orders/{created.Id}", created);
        })
        .WithValidation<CreateOrderRequest>();

        group.MapPut("/{id}", (int id, UpdateOrderRequest request, IOrderRepository orderRepo) =>
        {
            var order = new Order
            {
                Id = id,
                CustomerId = request.CustomerId,
                Items = request.Items
            };
            return orderRepo.Update(order) ? Results.Ok(order) : Results.NotFound();
        })
        .WithValidation<UpdateOrderRequest>();

        group.MapDelete("/{id}", (int id, IOrderRepository orderRepo) =>
            orderRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
