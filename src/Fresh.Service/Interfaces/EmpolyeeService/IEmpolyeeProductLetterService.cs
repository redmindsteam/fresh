using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Interfaces.EmpolyeeService
{
    public interface IEmpolyeeProductLetterService 
    {
        Task<bool> CreateAsync(ProductLetter item);
        Task<bool> UpdateAsync(int id, ProductLetter entity);
        Task<bool> DeleteAsync(int id);
        Task<ProductLetter> GetByIdAsync(int id);
        Task<IList<ProductLetter>> GetAllAsync(int skip, int take);
    }
}
