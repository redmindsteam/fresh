using Fresh.Service.Interfaces.Security;
using Org.BouncyCastle.Crypto.Generators;

namespace Fresh.Service.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public (string PasswordHash, string Salt) Hash(string password)
        {
                string salt = GenerateSalt();
                string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
                return (PasswordHash: hash, Salt: salt);
        }

        public bool Verify(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }
        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
