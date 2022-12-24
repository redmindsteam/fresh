using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Interfaces.EmpolyeeService;


namespace Fresh.Service.Services.Empolyee
{
    public class EmpolyeeProductLetterService : IEmpolyeeProductLetterService
    {
        ProductLetterRepository productLetterRepository = new ProductLetterRepository();
        public async Task<bool> CreateAsync(ProductLetter item)
        {
            try
            {
                var resault = await productLetterRepository.CreateAsync(item);
                if (resault)
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
    }
}
