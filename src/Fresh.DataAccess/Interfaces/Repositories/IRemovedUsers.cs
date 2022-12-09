namespace Fresh.DataAccess.Interfaces
{
    public interface IRemovedUsers
    {
        Task<string> GetAllRemovedUsers();
        Task<bool> AddRemovedUsers(int id);
    }
}
