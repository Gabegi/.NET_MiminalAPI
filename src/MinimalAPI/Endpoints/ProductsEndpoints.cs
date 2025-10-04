using Core.Entities;
using Infrastructure;
using MinimalAPI.Extensions;
using MinimalAPI.Models.Requests;

namespace MinimalAPI.Endpoints;

public static class ProductsEndpoints
{
    public static void MapProducts(this WebApplication app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", (IRandomProductRepository productRepo) => productRepo.GetAll());

        group.MapGet("/{id}", (int id, IRandomProductRepository productRepo) =>
        {
            var product = productRepo.GetById(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        group.MapPost("/", (CreateProductRequest request, IRandomProductRepository productRepo) =>
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            var created = productRepo.Add(product);
            return Results.Created($"/products/{created.Id}", created);
        })
        .WithValidation<CreateProductRequest>();

        group.MapPut("/{id}", (int id, UpdateProductRequest request, IRandomProductRepository productRepo) =>
        {
            var product = new Product
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            return productRepo.Update(product) ? Results.Ok(product) : Results.NotFound();
        })
        .WithValidation<UpdateProductRequest>();

        group.MapDelete("/{id}", (int id, IRandomProductRepository productRepo) =>
            productRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
