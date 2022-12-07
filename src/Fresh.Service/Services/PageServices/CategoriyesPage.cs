using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class CategoriyesPage
    {
        public async Task<List<Category>> GetCategories()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            IList<Category> categories = await categoryRepository.GetAllAsync();
            return categories.ToList();
        }
        public async Task<bool> AddCategories(string Categoryname )
        {
            List<Category> categories = await GetCategories();
            bool resalt = categories.Any(c => c.Name == Categoryname);
            if (resalt == true)
            {
                return false;
            }
            else
            {
                Category category = new Category()
                {
                    Name = Categoryname,
                    Description = String.Empty,
                };
                ICategoryRepository categoryRepository = new CategoryRepository();
                return await categoryRepository.CreateAsync(category);
            }
        }
    }
}
