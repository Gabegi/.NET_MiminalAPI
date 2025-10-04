using EShop.Core.Entities;

namespace Infrastructure
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        Customer Add(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
    }
}
