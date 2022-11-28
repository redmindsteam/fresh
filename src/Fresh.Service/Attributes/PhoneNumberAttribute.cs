using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fresh.Service.Attributes
{
    public static class PhoneNumberAttribute
    {
        public static bool IsValid(string phoneNumber)
        {
            return new Regex(@"^[+998]{4}[0-9]{9}$").IsMatch(phoneNumber);
        }
    }
}