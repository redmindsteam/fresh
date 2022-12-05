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
            return views.ToList();

        }
    }
}
