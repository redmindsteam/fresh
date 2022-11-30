using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fresh.Service.Helpers
{
    public class PhoneNumberAttribute
    {
        public async Task<bool> IsValid(string phoneNumber)
        {
            try
            {
                var resault = new Regex(@"^([9]{2}[8][0-9]{9})$").IsMatch(phoneNumber);
                if (resault != true)
                {
                    return  false;
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