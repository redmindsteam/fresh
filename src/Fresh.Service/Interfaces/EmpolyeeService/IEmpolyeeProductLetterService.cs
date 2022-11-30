using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.EmpolyeeService
{
    public interface IEmpolyeeProductLetterService
    {
        public Task<bool> CreateAsync(ProductLetter item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<ProductLetter>> GetAllAsync(int skip, int take);
        public Task<ProductLetter> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, ProductLetter entity);
    }
}
