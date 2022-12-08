namespace Fresh.Service.Helpers
{
    public class PasswordAttribute
    {
        public async Task<bool> ValidationScore(string password)
        {
            try
            {
                if (password.Length > 6 && password.Length < 16)
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
