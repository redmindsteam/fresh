using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductService 
    {
        public Task<List<Product>> GetOrderedProductsByValue(int skip, int take);
        Task<bool> CreateAsync(Product item);
        Task<bool> UpdateAsync(int id, Product entity);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<IList<Product>> GetAllAsync(int skip, int take);
    }
}
