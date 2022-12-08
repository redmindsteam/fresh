using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.DataAccess.Interfaces
{
    public interface IRemovedUsers
    {
        Task<string> GetAllRemovedUsers();
        Task<bool> AddRemovedUsers(int id);
    }
}
