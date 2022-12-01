using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorRegisterService
    {
        public Task<bool> CreateAsync(User item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<User>> GetAllAsync(int skip, int take);
        public Task<User> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, User entity);
        public Task<string> UserValidationAsync(string identifier, string password);
        public Task<bool> UpdatePassHashByEmailAsync(string email, string password);
        public Task<bool> UpdatePassHashByPhoneAsync(string phoneNum, string password);
    }
}
