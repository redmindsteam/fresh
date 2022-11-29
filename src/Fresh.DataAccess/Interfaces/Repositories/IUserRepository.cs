using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository <User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByFullName(string fullname);
        Task<User> GetByPhoneNumber(string phonenumber);
    }
}
