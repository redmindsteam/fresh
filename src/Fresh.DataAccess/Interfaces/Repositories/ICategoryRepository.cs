using Fresh.Domain.Entities;

namespace Fresh.DataAccess.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByName(string Name);
    }
}
