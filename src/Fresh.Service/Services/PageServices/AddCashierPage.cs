using Fresh.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class AddCashierPage
    {
        public async Task<(bool result,string status)> IsValidInputs(string password,string passportseria,string phonenumber)
        {
            PassportSeriaAttribute passportSeriaAttribute = new PassportSeriaAttribute();
            PasswordAttribute passwordAttribute = new PasswordAttribute();
            PhoneNumberAttribute phoneNumberAttribute = new PhoneNumberAttribute();
            if (await passportSeriaAttribute.IsValid(passportseria))
            {
                if(await passwordAttribute.ValidationScore(password))
                {
                    if(await phoneNumberAttribute.IsValid(phonenumber))
                    {
                        return (result: true, status: "Succesfuly");
                    }
                    else
                    {
                        return (result: false, status: "PhoneNumber Is Wrong");
                    }
                }
                else
                {
                    return (result: false, status: "Password Is Wrong");
                }
            }
            else
            {
                return (result: false, status: "PassportSeria Is Wrong");
               
            }
        }
    }
}
