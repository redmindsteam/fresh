using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Director
{
    public class DirectorProductLetterService : IDirectorProductLetterService
    {
        ProductLetterRepository productLetterRepository = new ProductLetterRepository();
        public async Task<bool> CreateAsync(ProductLetter item)
        {
            try
            {
                var resault = await productLetterRepository.CreateAsync(item);
                if (resault != false)
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

        public async Task<bool> DeleteAsync(int id)
        {
            var resault = await productLetterRepository.DeleteAsync(id);
            if (resault != false)
            {
                return true;
            }
            return false;
        }

        public async Task<IList<ProductLetter>> GetAllAsync()
        {
            try
            {
                var resault = await productLetterRepository.GetAllAsync();
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

        public Task<ProductLetter> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, ProductLetter entity)
        {
            try
            {
                var resault = await productLetterRepository.UpdateAsync(id, entity);
                if (resault != false)
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
    }
}
