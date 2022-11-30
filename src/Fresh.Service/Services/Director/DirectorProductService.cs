using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Services.Director
{
    public class DirectorProductService : IDirectorProductService
    {
        public Task<bool> CreateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
