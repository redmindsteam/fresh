using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorCheckService
    {
        public Task<bool> DeleteAsync(int id);
        public Task<IList<Check>> GetAllAsync(int skip, int take);
    }
}
