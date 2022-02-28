using Domain.Interfaces;
using Domain.Models;

namespace InMemoryRepository.Repositories
{
    public class InMemoryAddressRepository : IAddressRepository
    {
        public Address GetAddress(string postcode, string houseNameNumber)
        {
            return new Address();
        }
    }
}
