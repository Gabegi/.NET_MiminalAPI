using EShop.Core.Entities;
using Infrastructure;

namespace MinimalAPI.Endpoints;

public static class CustomersEndpoints
{
    public static void MapCustomers(this WebApplication app)
    {
        var group = app.MapGroup("/customers");

        group.MapGet("/", (ICustomerRepository customerRepo) => customerRepo.GetAll());

        group.MapGet("/{id}", (int id, ICustomerRepository customerRepo) =>
        {
            var customer = customerRepo.GetById(id);
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        });

        group.MapPost("/", (Customer customer, ICustomerRepository customerRepo) =>
            Results.Created($"/customers/{customerRepo.Add(customer).Id}", customer));

        group.MapPut("/{id}", (int id, Customer customer, ICustomerRepository customerRepo) =>
        {
            customer.Id = id;
            return customerRepo.Update(customer) ? Results.Ok(customer) : Results.NotFound();
        });

        group.MapDelete("/{id}", (int id, ICustomerRepository customerRepo) =>
            customerRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
