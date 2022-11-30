using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
