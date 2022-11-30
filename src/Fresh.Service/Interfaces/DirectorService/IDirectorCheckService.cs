using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorCheckService 
    {
        public Task<bool> CreateAsync(Check item);
        public Task<bool> DeleteAsync(int id);
        public Task<IList<Check>> GetAllAsync(int skip, int take);
        public Task<Check> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, Check item);

    }
}
