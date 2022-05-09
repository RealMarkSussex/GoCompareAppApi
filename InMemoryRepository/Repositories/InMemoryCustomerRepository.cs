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
                new Customer() { CustomerID = 1, Email = "marksussex6@gmail.com", HPass = "nypBGuMzVp9Wqi3iLUb0/J1sEtcII6n5gdPYD8A8oI4="}
            };
        }
    }
}
