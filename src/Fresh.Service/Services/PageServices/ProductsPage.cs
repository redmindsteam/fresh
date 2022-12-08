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
                ICategoryRepository categoryRepository = new CategoryRepository();
                IProductRepository productRepository = new ProductRepository();
                Product product = new Product()
                {
                    Name = productview.Name,
                    CategoryId = (await categoryRepository.GetByName(productview.Category)).Id,
                    Price = productview.Price,
                    Value = productview.Available,
                };
                return await productRepository.UpdateAsync(id, product);
            }
            catch
            {
                return false;
            }
            
        }
        public async Task<bool> AddProdact(Product product)
        {
            IProductRepository productRepository = new ProductRepository();
            return await productRepository.CreateAsync(product);
        }
    }
}
