using System.Text.RegularExpressions;

namespace Fresh.Service.Helpers
{
    public class PassportSeriaAttribute
    {
        public async Task<bool> IsValid(string passportSeria)
        {
            try
            {
                var resault = new Regex(@"^[A-Z]{2}[0-9]{7}$").IsMatch(passportSeria);
                if (resault != true)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
