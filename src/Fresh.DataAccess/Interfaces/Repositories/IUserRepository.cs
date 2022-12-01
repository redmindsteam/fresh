using Fresh.Domain.Entities;

namespace Fresh.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByFullNameAsync(string fullname);
        Task<User> GetByPhoneNumberAsync(string phonenumber);
    }
}
