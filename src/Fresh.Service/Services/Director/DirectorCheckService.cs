using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Director
{
    public class DirectorCheckService : IDirectorCheckService
    {
        CheckRepository checkRepository = new CheckRepository();

        public async Task<bool> CreateAsync(Check item)
        {
            try
            {
                var resault = await checkRepository.CreateAsync(item);
                if (resault != false)
                {
                    return true;
                }
                return false;
            }
            catch
            { 
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var resault = await checkRepository.DeleteAsync(id);
                if (resault != false)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Check>> GetAllAsync(int skip, int take)
        {
            try
            { 
                var resault = await checkRepository.GetAllAsync(skip, take);
                if (resault != null)
                { 
                    return resault;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<Check> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Check item)
        {
            throw new NotImplementedException();
        }
    }
}
