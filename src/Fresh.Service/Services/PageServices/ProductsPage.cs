using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.ViewModels;

namespace Fresh.Service.Services.PageServices
{
    public class ProductPage
    {
        public async Task<List<ProductsView>> GetProductViews()
        {
            IProductRepository repository = new ProductRepository();
            IList<ProductsView> views = new List<ProductsView>();
            IList<Product> products = await repository.GetAllAsync();
            foreach (Product product in products)
            {
                    ICategoryRepository categoryRepository = new CategoryRepository();
                    Category categorie = await categoryRepository.GetByIdAsync(product.CategoryId);
                    ProductsView view = new ProductsView()
                    {
                        Id = product.Id,
                        Name=product.Name,
                        Category= categorie.Name,
                        Price=product.Price,
                        Available=product.Value,
                    };
                    views.Add(view);
            }

            return views.OrderBy(x=>x.Available).ToList();

        }
        public async Task<bool> DeleteProduct(ProductsView productView)
        {
            ProductRepository productRepository = new ProductRepository();

            return await productRepository.DeleteAsync(productView.Id);
        }
        public async Task<bool> UpdateProduct(int id,ProductsView productview)
        {
            try
            {
                ProductRepository productRepository = new();
                Product product = await productRepository.GetByIdAsync(productview.Id);
                {
                    product.Id = productview.Id;
                    product.Name = productview.Name;
                    var categoryRepository = new CategoryRepository();
                    product.CategoryId = (await categoryRepository.GetByName(productview.Category)).Id;
                    product.Price = productview.Price;
                    product.Value = productview.Available;
                }
             
                return await productRepository.UpdateAsync(id, product);
            }
            catch
            {
                return false;
            }
            
        }
    }
}
