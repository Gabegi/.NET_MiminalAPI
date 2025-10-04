using EShop.Core.Entities;

namespace Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public IEnumerable<Order> GetAll() => _orders;

        public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetByCustomerId(int customerId) =>
            _orders.Where(o => o.CustomerId == customerId);

        public Order Add(Order order)
        {
            var newId = _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1;
            order.Id = newId;
            _orders.Add(order);
            return order;
        }

        public bool Update(Order order)
        {
            var existing = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existing is null) return false;

            existing.CustomerId = order.CustomerId;
            existing.OrderDate = order.OrderDate;
            existing.Items = order.Items;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _orders.FirstOrDefault(o => o.Id == id);
            if (existing is null) return false;
            _orders.Remove(existing);
            return true;
        }
    }
}
