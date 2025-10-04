using EShop.Core.Entities;

namespace Infrastructure
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        IEnumerable<Order> GetByCustomerId(int customerId);
        Order Add(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
