using EShop.Core.Entities;

namespace Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public IEnumerable<Customer> GetAll() => _customers;

        public Customer? GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);

        public Customer Add(Customer customer)
        {
            var newId = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
            customer.Id = newId;
            _customers.Add(customer);
            return customer;
        }

        public bool Update(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing is null) return false;

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == id);
            if (existing is null) return false;
            _customers.Remove(existing);
            return true;
        }
    }
}
