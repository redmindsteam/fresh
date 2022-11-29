using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Helpers;
using Fresh.Service.Interfaces.DirectorService;
using Fresh.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Director
{
    public class DirectorRegisterService : IDirectorRegisterService
    {
        public async Task<bool> CreateAsync(User item)
        {
            try
            {
                PassportSeriaAttribute passportSeriaAttribute = new PassportSeriaAttribute();
                var resaultPassportSeria = await passportSeriaAttribute.IsValid(item.PassportSeria);

                PasswordAttribute passwordAttribute = new PasswordAttribute();
                var resaultPasswordAtribute = await passwordAttribute.ValidationScore(item.PasswordHash);

                PhoneNumberAttribute phoneNumberAttribute = new PhoneNumberAttribute(); 
                var resaultPhoneNUmber = await phoneNumberAttribute.IsValid(item.PhoneNumber);

                if (item.FullName != null)
                {
                    if (resaultPassportSeria != false && resaultPasswordAtribute != false && resaultPhoneNUmber != false)
                    {
                        PasswordHasher passwordHasher = new PasswordHasher();
                        var resaultPasswordHasher = await passwordHasher.Hash(item.PasswordHash);
                        if (resaultPasswordHasher.PasswordHash != null && resaultPasswordHasher.Salt != null)
                        {
                            UserRepository userRepository = new UserRepository();

                            item.IsAdmin = false;
                            item.PasswordHash = resaultPasswordHasher.PasswordHash;
                            item.Salt = resaultPasswordHasher.Salt;

                            var resault = await userRepository.CreateAsync(item);
                            if (resault != false)
                            {
                                return true;
                            }
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    { 
                    return false;
                    }
                }
                else
                { 
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
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
