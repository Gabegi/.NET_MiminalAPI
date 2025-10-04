using EShop.Core.Entities;
using Infrastructure;

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

        group.MapPost("/", (Order order, IOrderRepository orderRepo) =>
            Results.Created($"/orders/{orderRepo.Add(order).Id}", order));

        group.MapPut("/{id}", (int id, Order order, IOrderRepository orderRepo) =>
        {
            order.Id = id;
            return orderRepo.Update(order) ? Results.Ok(order) : Results.NotFound();
        });

        group.MapDelete("/{id}", (int id, IOrderRepository orderRepo) =>
            orderRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
