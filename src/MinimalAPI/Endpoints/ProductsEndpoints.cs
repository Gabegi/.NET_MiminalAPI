using Core.Entities;
using Infrastructure;

namespace MinimalAPI.Endpoints;

public static class ProductsEndpoints
{
    public static void MapProducts(this WebApplication app, RandomProductRepository productRepo)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", () => productRepo.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            var product = productRepo.GetById(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        group.MapPost("/", (Product product) =>
            Results.Created($"/products/{productRepo.Add(product).Id}", product));

        group.MapPut("/{id}", (int id, Product product) =>
        {
            product.Id = id;
            return productRepo.Update(product) ? Results.Ok(product) : Results.NotFound();
        });

        group.MapDelete("/{id}", (int id) =>
            productRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
