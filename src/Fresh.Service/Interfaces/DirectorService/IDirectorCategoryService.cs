using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorCategoryService
    {
        public Task<bool> CreateAsync(Category item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, Category entity);
    }
}
