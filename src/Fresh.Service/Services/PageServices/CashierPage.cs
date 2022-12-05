using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Security;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class CashierPage
    {
        public async Task<IList<User>> GetAllCashiers()
        {
            IUserRepository userRepository = new UserRepository();
            IList<User> users = await userRepository.GetAllAsync();
            return users;
        }
        public async  Task<List<CashierView>> GetCashierViews()
        {
            IList<CashierView> views = new List<CashierView>();
            IList<User> users = await GetAllCashiers();
            foreach (User user in users)
            {
                if (user.Id == 1)
                {
                    continue;
                }
                else
                {
                    CashierView view = new CashierView()
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        PassportSeria = user.PassportSeria,
                    };
                    views.Add(view);
                }
            }
            return views.ToList();
            
        }
        public async Task<bool> AddCashier(CashierView cashierView)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            var passwordsalt = passwordHasher.Hash(cashierView.Password);
            User user = new User()
            {
                FullName = cashierView.FullName,
                Email=cashierView.Email,
                PasswordHash=passwordsalt.PasswordHash,
                Salt=passwordsalt.Salt,
                PhoneNumber=cashierView.PhoneNumber,
                PassportSeria=cashierView.PassportSeria,
                IsAdmin=0,
            };
            UserRepository userRepository = new UserRepository();
            return await userRepository.CreateAsync(user);
        }
        public async Task<bool> DeleteCashier(CashierView cashierView)
        {
            UserRepository userRepository = new UserRepository();
            User user = await userRepository.GetByEmailAsync(cashierView.Email);
            return await userRepository.DeleteAsync(user.Id);
        }
    }
}