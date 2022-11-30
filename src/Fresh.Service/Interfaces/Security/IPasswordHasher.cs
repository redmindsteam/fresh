namespace Fresh.Service.Interfaces.Security
{
    public interface IPasswordHasher
    {
        public (string PasswordHash, string Salt) Hash(string password);

        public bool Verify(string password, string salt, string passwordHash);
    }
}