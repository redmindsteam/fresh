using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Director
{
    public class DirectorProductService : IDirectorProductService
    {
        public Task<bool> CreateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Product>> GetOrderedProductsByValue(int skip, int take)
        {
            DataAccess.Repositories.ProductRepository product = new DataAccess.Repositories.ProductRepository();
            var productst = await product.GetAllAsync(skip, take);
            return productst.OrderBy(x => x.Value).ToList();
        }
    }
}
