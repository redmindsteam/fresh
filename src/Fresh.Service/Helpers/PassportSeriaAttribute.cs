using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
