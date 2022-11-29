using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Director
{
    public class DirectorCategoryService : IDirectorCategoryService
    {
        public Task<bool> CreateAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
