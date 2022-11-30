﻿using Fresh.Domain.Entities;

namespace Fresh.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByFullName(string fullname);
        Task<User> GetByPhoneNumber(string phonenumber);
    }
}
