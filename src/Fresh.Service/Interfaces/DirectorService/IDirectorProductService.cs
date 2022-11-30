using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorProductService : IGenericService<Product>
    {
        public Task<List<Product>> GetOrderedProductsByValue(int skip, int take);
    }
}
