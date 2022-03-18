using Domain.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICustomerRepository customerRepository;

        public LoginService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public bool Login(string? email, string? password)
        {
            if(email != null && password != null)
            {
                var hpass = HashPassword(password);
                var customer = customerRepository.GetCustomer(email, hpass);
                return customer != null;
            }
            return false;
        }

        private string HashPassword(string password)
        {
            var salt = new byte[16] {1, 0, 62, 254, 33, 7, 82, 8, 212, 56, 14, 90, 147, 0, 65, 199 };
            
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
