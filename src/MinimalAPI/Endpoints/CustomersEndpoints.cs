using EShop.Core.Entities;
using Infrastructure;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Requests;

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

        group.MapPost("/", (CreateCustomerRequest request, ICustomerRepository customerRepo) =>
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email
            };
            var created = customerRepo.Add(customer);
            return Results.Created($"/customers/{created.Id}", created);
        })
        .WithValidation<CreateCustomerRequest>();

        group.MapPut("/{id}", (int id, UpdateCustomerRequest request, ICustomerRepository customerRepo) =>
        {
            var customer = new Customer
            {
                Id = id,
                Name = request.Name,
                Email = request.Email
            };
            return customerRepo.Update(customer) ? Results.Ok(customer) : Results.NotFound();
        })
        .WithValidation<UpdateCustomerRequest>();

        group.MapDelete("/{id}", (int id, ICustomerRepository customerRepo) =>
            customerRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
