using Fresh.Service.Interfaces.Security;

namespace Fresh.Service.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public async Task<(string PasswordHash, string Salt)> Hash(string password)
        {
            string salt = await GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return (PasswordHash: hash, Salt: salt);
        }

        public async Task<bool> Verify(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }
        public async Task<string> GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
