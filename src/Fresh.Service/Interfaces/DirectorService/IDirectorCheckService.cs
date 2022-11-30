using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorCheckService
    {
        Task<bool> CreateAsync(Check item);
        Task<bool> UpdateAsync(int id, Check entity);
        Task<bool> DeleteAsync(int id);
        Task<Check> GetByIdAsync(int id);
        Task<IList<Check>> GetAllAsync(int skip, int take);
    }
}
