using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorCategoryService
    {
        Task<bool> CreateAsync(Category item);
        Task<bool> UpdateAsync(int id, Category entity);
        Task<bool> DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IList<Category>> GetAllAsync(int skip, int take);
    }
}
