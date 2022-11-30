using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Services.Director
{
    public class DirectorCategoryService : IDirectorCategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public async Task<bool> CreateAsync(Category item)
        {
            try
            { 
                var resault = await categoryRepository.CreateAsync(item);
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
            try
            {
                var resault = await categoryRepository.DeleteAsync(id);
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

        public async Task<IList<Category?>> GetAllAsync(int skip, int take)
        {
            try
            {
                var resault = await categoryRepository.GetAllAsync(skip, take);
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

        public async Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, Category entity)
        {
            try
            {
                var resault = await categoryRepository.UpdateAsync(id, entity);
                if (resault == true)
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
