using Core.Entities;

namespace Infrastructure
{
    public class RandomProductRepository : IRandomProductRepository
    {
        private readonly List<Product> _products;
        private readonly Random _random = new();

        public RandomProductRepository(int initialCount = 10)
        {
            // Pre-generate some random products
            _products = Enumerable.Range(1, initialCount).Select(i => new Product
            {
                Id = i,
                Name = $"Product {i}",
                Description = $"Random product {i}",
                Price = Math.Round((decimal)(_random.NextDouble() * 100), 2)
            }).ToList();
        }

        // READ
        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        // CREATE
        public Product Add(Product product)
        {
            var newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            product.Id = newId;
            _products.Add(product);
            return product;
        }

        // UPDATE
        public bool Update(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing is null) return false;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            return true;
        }

        // DELETE
        public bool Delete(int id)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing is null) return false;
            _products.Remove(existing);
            return true;
        }

    }
}
