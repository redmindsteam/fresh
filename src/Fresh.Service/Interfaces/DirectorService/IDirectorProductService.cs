using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductService 
    {
        public Task<bool> CreateAsync(Product item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<Product>> GetAllAsync(int skip, int take);
        public Task<Product> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, Product item);
        public Task<List<Product>> GetOrderedProductsByValue(int skip, int take);
    }
}
