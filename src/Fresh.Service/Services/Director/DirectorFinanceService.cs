using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Director
{
    public class DirectorFinanceService : IDirectorFinanceService
    {
        public Task<bool> CreateAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Category item)
        {
            throw new NotImplementedException();
        }
    }
}
