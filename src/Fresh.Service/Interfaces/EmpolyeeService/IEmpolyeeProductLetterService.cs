using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.EmpolyeeService
{
    public interface IEmpolyeeProductLetterService
    {
        public Task<bool> CreateAsync(ProductLetter item);
    }
}
