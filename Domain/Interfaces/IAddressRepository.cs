using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAddressRepository
    {
        public Address GetAddress(string postcode, string houseNameNumber);
    }
}
