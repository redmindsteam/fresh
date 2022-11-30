using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.EmpolyeeService;


namespace Fresh.Service.Empolyee
{
    public class EmpolyeeProductLetterService : IEmpolyeeProductLetterService
    {
        public Task<bool> CreateAsync(ProductLetter item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProductLetter>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ProductLetter> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, ProductLetter entity)
        {
            throw new NotImplementedException();
        }
    }
}
