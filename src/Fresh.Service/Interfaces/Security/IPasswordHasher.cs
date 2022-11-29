namespace Fresh.Service.Interfaces.Security
{
    public interface IPasswordHasher
    {
        public Task<(string PasswordHash, string Salt)> Hash(string password);

        public Task<bool> Verify(string password, string salt, string passwordHash);
    }
}