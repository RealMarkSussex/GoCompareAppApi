using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer? GetCustomer(string email, string hpass);
        public List<Customer> GetCustomers();
    }
}
