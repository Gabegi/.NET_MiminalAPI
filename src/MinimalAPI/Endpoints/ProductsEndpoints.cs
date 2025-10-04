using Core.Entities;
using Infrastructure;

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

        group.MapPost("/", (Product product, IRandomProductRepository productRepo) =>
            Results.Created($"/products/{productRepo.Add(product).Id}", product));

        group.MapPut("/{id}", (int id, Product product, IRandomProductRepository productRepo) =>
        {
            product.Id = id;
            return productRepo.Update(product) ? Results.Ok(product) : Results.NotFound();
        });

        group.MapDelete("/{id}", (int id, IRandomProductRepository productRepo) =>
            productRepo.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}
