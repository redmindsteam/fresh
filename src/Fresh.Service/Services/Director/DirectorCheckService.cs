﻿using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.DirectorService;

namespace Fresh.Service.Services.Director
{
    public class DirectorCheckService : IDirectorCheckService
    {
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
