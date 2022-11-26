using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public Task<bool> CreateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
