using Fresh.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fresh.Service.Tools
{
    public static class ToolBox
    {
        public async static Task<(string number,bool status)> IsPhoneNumber(string trash)
        {
            var returner = string.Empty;
            int tool = 0;
            foreach(var item in trash)
            {
                if (int.TryParse($"{item}", out tool))
                    returner += $"{tool}";
            }
            PhoneNumberAttribute phoneNumberAttribute = new PhoneNumberAttribute();
            if (await phoneNumberAttribute.IsValid(returner))
                return (returner, true);
            return (string.Empty,false);
        }
    }
}
