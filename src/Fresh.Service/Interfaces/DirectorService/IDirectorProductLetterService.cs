using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductLetterService
    {
        Task<bool> CreateAsync(ProductLetter item);
        Task<bool> UpdateAsync(int id, ProductLetter entity);
        Task<bool> DeleteAsync(int id);
        Task<ProductLetter> GetByIdAsync(int id);
        Task<IList<ProductLetter>> GetAllAsync(int skip, int take);
    }
}
