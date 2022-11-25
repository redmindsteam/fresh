using F.Service.Interfaces.Security;
using Fresh.Service.Interfaces.Security;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Security
{
    internal class PasswordHasher : IPasswordHasher
    {
        public (string passwordHash, string salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string strongpassword =salt + password;
            string hash = BCrypt.Net.BCrypt.HashPassword(strongpassword);
            return (passwordHash: hash,salt: salt);
        }

        public bool Verify(string password, string salt, string hash)
        {
            throw new NotImplementedException();
        }
    }
}
