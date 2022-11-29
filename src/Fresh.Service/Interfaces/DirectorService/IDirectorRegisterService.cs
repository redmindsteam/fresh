using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorRegisterService : IGenericService<User>
    {
        public Task<(string error, bool result)> UserValidation(string identifier, string password);
    }
}
