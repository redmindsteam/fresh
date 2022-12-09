using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fresh.Service.Helpers
{
    public class EmailAttribute
    {
        public bool IsValid(string email)
        {
            if (email is null) return false;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (regex.Match(email.ToString()!).Success)
                return true;
            return false;
        }
    }
}
