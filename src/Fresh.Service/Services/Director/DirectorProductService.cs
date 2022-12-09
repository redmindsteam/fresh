using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Director
{
    public class DirectorProductService : IDirectorProductService
    {
        ProductRepository productRepository = new ProductRepository();
        public async Task<bool> CreateAsync(Product item)
        {
            try
            {
                if (item.Price != null)
                {
                    var result = await productRepository.CreateAsync(item);
                    if (result != true)
                    {
                        return false;
                    }
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
                var resauklt = await productRepository.DeleteAsync(id);
                if (resauklt != false)
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

        public async Task<IList<Product>> GetAllAsync()
        {
            try
            {
                var resault = await productRepository.GetAllAsync();
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

        public async Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, Product item)
        {
            try
            {
                if (item.Price != null)
                {
                    var result = await productRepository.UpdateAsync(id, item);
                    if (result != true)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Product>> GetOrderedProductsByValue()
        {
            DataAccess.Repositories.ProductRepository product = new DataAccess.Repositories.ProductRepository();
            var productst = await product.GetAllAsync();
            return productst.OrderBy(x => x.Value).ToList();
        }

        //public async Task<bool> UpdateProduct(IList<Product> entity)
        //{
        //    ProductRepository products = new ProductRepository();
        //    var ress = await products.UpdateProduct(entity);
        //    if (ress == false)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
