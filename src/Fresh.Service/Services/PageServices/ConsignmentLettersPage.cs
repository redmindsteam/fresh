using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.ViewModels;
using Fresh.Service.ViewModels.ViewDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class ConsignmentLettersPage
    {
        public async Task<IList<ConsignmentLetterView>> GetAllCL()
        {
            try
            {
                ProductLetterRepository productLetterRepository = new();
                var allLetters = await productLetterRepository.GetAllAsync();
                UserRepository userRepository = new();
                var viewModels = new List<ConsignmentLetterView>();
                foreach (var one in allLetters)
                    viewModels.Add(new ConsignmentLetterView
                    {
                        Id= one.Id,
                        Cashier = (await userRepository.GetByIdAsync(one.UserId)).FullName,
                        DateTime = DateTime.Parse(one.Date),
                        TotallPrice = one.Price,
                    }) ;
                return viewModels;
            }
            catch
            {
                return new List<ConsignmentLetterView>();
            }
        }
        public async Task<List<ConsigmentLetterViewDetails>> GetConsigmentLetterDetailsById(int id)
        {
            ProductLetterRepository repository = new();
            var consigmentLetters = await repository.GetByIdAsync(id);
            return JsonConvert.DeserializeObject<List<ConsigmentLetterViewDetails>>(consigmentLetters.ProductDescription);
        }
    }
}
