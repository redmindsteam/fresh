using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Attributes;
using Fresh.Service.Interfaces.DirectorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Director
{
    public class DirectorRegisterService : IDirectorRegisterService
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
        /// <summary>
        /// / Identifies user in login page
        /// </summary>
        /// <param name="identifier">Email or PhoneNumber</param>
        /// <param name="password">UserInput password</param>
        /// <returns></returns>
        public async Task<(string error,bool result)> UserValidation(string identifier, string password)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                Security.PasswordHasher hasher = new Security.PasswordHasher();
                User user = await userRepository.GetByEmail(identifier);
               /// if (user == null) userRepository.GetByPhoneNumber(identifier);
                if (user != null)
                {
                    if (hasher.Verify(password, user.Salt, user.PasswordHash))
                    {
                        CurrentRegistrar.Registrar = user;
                        return (string.Empty, true);
                    }
                    else
                        return ("Incorrect password", false);
                }
                else
                    return ("User not found", false);
            }
            catch
            {
                return ("Something went error",false);
            }
        }
    }
}
