using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductLetterService
    {
        public Task<bool> CreateAsync(ProductLetter item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<ProductLetter>> GetAllAsync(int skip, int take);
        public Task<ProductLetter> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, ProductLetter entity);
    }
}
