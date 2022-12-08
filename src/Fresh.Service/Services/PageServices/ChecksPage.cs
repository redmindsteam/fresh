using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class CheckPage
    {
        public async Task<List<ChecksView>> GetChecksViews()
        {
            ICheckRepository repository = new CheckRepository();
            IList<ChecksView> views = new List<ChecksView>();
            IList<Check> checks = await repository.GetAllAsync();
            foreach (Check check in checks)
            {
                IUserRepository userRepository = new UserRepository();
                User user = await userRepository.GetByIdAsync(check.UserId);
                ChecksView view = new ChecksView()
                {
                    Date=check.Date.ToString(),
                    Caisher= user.FullName,
                    Summ=check.TotalSum,
                };
                views.Add(view);
            }

            return views.ToList();

        }
    }
}
