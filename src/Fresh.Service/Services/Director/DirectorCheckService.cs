using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Director
{
    public class DirectorCheckService : IDirectorCheckService
    {
        DirectorCheckService directorCheckService = new DirectorCheckService();
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var resault = await directorCheckService.DeleteAsync(id);
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
                var resault = await directorCheckService.GetAllAsync(skip, take);
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
    }
}
