using Fresh.Service.Helpers;
using Fresh.Service.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class AddCashierPage
    {
        // was Abdulaziz and Sanjar's work
        public async Task<(bool result,string status)> IsValidInputs(string email,string password,string passportseria,string phonenumber)
        {
            PassportSeriaAttribute passportSeriaAttribute = new PassportSeriaAttribute();
            PasswordAttribute passwordAttribute = new PasswordAttribute();
            PhoneNumberAttribute phoneNumberAttribute = new PhoneNumberAttribute();
            EmailAttribute emailAttribute = new EmailAttribute();
            if (!emailAttribute.IsValid(email))
                return (false, "Not valid email entered");
            if (!await passwordAttribute.ValidationScore(password))
                return (result: false, status: "Password must contain minimum six, maximum sixteen letters");
            if (!await passportSeriaAttribute.IsValid(passportseria))
                return (result: false, status: "PassportSeria is not in correct format");
            if (!(await ToolBox.IsPhoneNumber(phonenumber)).status)
                return (result: false, status: "PhoneNumber is not valid");
            return (true, string.Empty);
        }
    }
}