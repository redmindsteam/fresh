using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.EmpolyeeService
{
    public interface IEmpolyeeRegisterService
    {
        Task<bool> CreateAsync(User item);
        Task<bool> UpdateAsync(int id, User entity);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IList<User>> GetAllAsync(int skip, int take);
    }
}
