using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Attributes;
using Fresh.Service.Helpers;
using Fresh.Service.Interfaces.DirectorService;
using Fresh.Service.Security;
using Fresh.Service.Security.ConnectionVerifiers;
using Fresh.Service.Tools;

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
                        var resaultPasswordHasher = passwordHasher.Hash(item.PasswordHash);
                        if (resaultPasswordHasher.PasswordHash != null && resaultPasswordHasher.Salt != null)
                        {
                            UserRepository userRepository = new UserRepository();

                            item.IsAdmin = 0;
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                DirectorRegisterService directorRegisterService = new DirectorRegisterService();
                var resault = await directorRegisterService.DeleteAsync(id);

                if (resault != false)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<User?>> GetAllAsync(int skip, int take)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                var users = await userRepository.GetAllAsync(skip, take);
                if (users != null)
                {
                    return users;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAsync(int id, User item)
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
                        var resaultPasswordHasher = passwordHasher.Hash(item.PasswordHash);
                        if (resaultPasswordHasher.PasswordHash != null && resaultPasswordHasher.Salt != null)
                        {
                            UserRepository userRepository = new UserRepository();

                            item.IsAdmin = 0;
                            item.PasswordHash = resaultPasswordHasher.PasswordHash;
                            item.Salt = resaultPasswordHasher.Salt;

                            var resault = await userRepository.UpdateAsync(id, item);
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
        public async Task<string> UserValidationAsync(string identifier, string password)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                PasswordHasher hasher = new PasswordHasher();
                User user = new User();
                var isphone = await ToolBox.IsPhoneNumber(identifier);
                if (isphone.status)
                    user = await userRepository.GetByPhoneNumberAsync(isphone.number);
                else
                    user = await userRepository.GetByEmailAsync(identifier);
                if (user != null)
                {
                    if (hasher.Verify(password, user.Salt, user.PasswordHash))
                    {
                        CurrentUserSingelton.Instance = user;
                        return string.Empty;
                    }
                    else
                        return "Incorrect password";
                }
                else
                    return "User not found";
            }
            catch
            {
                return "Something went wrong";
            }
        }
        public async Task<string> ConfirmationProvider(string identifier)
        {
            var IsphoneResponse = await ToolBox.IsPhoneNumber(identifier);
            if (IsphoneResponse.status)
                return GSMPhoneVerificator.SendSingleMessage("+"+IsphoneResponse.number);
            else
                return EmailVerificator.VerifMail(identifier).rand;
        }

        public async Task<bool> UpdatePassHashByEmailAsync(string email,string password)
        {
            IUserRepository userRepository = new UserRepository();
            PasswordHasher hasher = new PasswordHasher();
            var user = await userRepository.GetByEmailAsync(email);
            var security_assets = hasher.Hash(password);
            if(user.PasswordHash != security_assets.PasswordHash)
            {
                user.PasswordHash = security_assets.PasswordHash;
                user.Salt = security_assets.Salt;
                IUserRepository userRepository2 = new UserRepository();
                return await userRepository2.UpdateAsync(user.Id, user);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdatePassHashByPhoneAsync(string phoneNum, string password)
        {
            UserRepository userRepository = new UserRepository();
            PasswordHasher hasher = new PasswordHasher();
            var user = await userRepository.GetByPhoneNumberAsync(phoneNum);
            var security_assets = hasher.Hash(password);
            if (user.PasswordHash != security_assets.PasswordHash)
            {
                user.PasswordHash = security_assets.PasswordHash;
                user.Salt = security_assets.Salt;
                return await userRepository.UpdateAsync(user.Id, user);
            }
            else
            {
                return false;
            }
        }
    }
}
