﻿using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.EmpolyeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.Empolyee
{
    public class EmployeeRegisterService : IEmpolyeeRegisterService
    {
        public Task<bool> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
