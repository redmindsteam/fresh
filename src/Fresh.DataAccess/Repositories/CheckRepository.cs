using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System.Data.SQLite;

namespace Fresh.DataAccess.Repositories
{
    public class CheckRepository : ICheckRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public Task<bool> CreateAsync(Check item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Check>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Check> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Check entity)
        {
            throw new NotImplementedException();
        }
    }
}
