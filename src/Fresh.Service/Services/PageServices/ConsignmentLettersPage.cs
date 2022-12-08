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
                        Description = one.ProductDescription,
                        Cashier = (await userRepository.GetByIdAsync(one.UserId)).FullName,
                        DateTime = DateTime.Parse(one.Date),
                        TotalPrice = one.Price
                    }) ;
                return viewModels;
            }
            catch
            {
                return new List<ConsignmentLetterView>();
            }
        }
    }
}
