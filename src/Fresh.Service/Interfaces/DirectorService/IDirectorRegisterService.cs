using Fresh.Domain.Entities;

namespace Fresh.Service.Interfaces.DirectorService
{
    public interface IDirectorRegisterService
    {
        public Task<(string error, bool result)> UserValidation(string identifier, string password);
    }
}
