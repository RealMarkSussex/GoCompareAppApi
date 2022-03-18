using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        public Customer? GetCustomer(string email, string hpass)
        {
            var customers = GetCustomers();

            return customers.FirstOrDefault(x => x.Email == email && x.HPass == hpass);
        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer() { CustomerID = 1, Email = "marksussex6@gmail.com", HPass = "B7BANGQTXF0aM3Oue/OKzjgdIt8n5xUBVL3jaLpnk2w="}
            };
        }
    }
}
