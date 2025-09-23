using Core.Entities;

namespace Infrastructure
{
    public interface IRandomProductRepository
    {
        Product Add(Product product);
        bool Delete(int id);
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        bool Update(Product product);
    }
}