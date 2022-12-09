using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.ViewModels;
using Fresh.Service.ViewModels.ViewDetails;
using Newtonsoft.Json;

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
                    Id = check.Id,
                    Date = check.Date.ToString(),
                    Caisher = user.FullName,
                    Summ = check.TotalSum,
                };
                views.Add(view);
            }

            return views.ToList();

        }
        public async Task<List<CheckDetailsView>> GetCheckDetailsById(int id)
        {
            ICheckRepository repository = new CheckRepository();
            var checks = await repository.GetByIdAsync(id);
            return JsonConvert.DeserializeObject<List<CheckDetailsView>>(checks.CheckDescription);
        }
    }
}
