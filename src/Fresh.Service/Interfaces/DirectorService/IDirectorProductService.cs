using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductService
    {
        Task<bool> CreateAsync(Product item);
        Task<bool> UpdateAsync(int id, Product entity);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<IList<Product>> GetAllAsync(int skip, int take);
    }
}
