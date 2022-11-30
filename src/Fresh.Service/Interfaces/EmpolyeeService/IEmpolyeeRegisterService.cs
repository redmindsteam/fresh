using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.EmpolyeeService
{
    public interface IEmpolyeeRegisterService
    {
        public Task<bool> CreateAsync(User item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<User>> GetAllAsync(int skip, int take);
        public Task<User> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, User entity);
    }
}
