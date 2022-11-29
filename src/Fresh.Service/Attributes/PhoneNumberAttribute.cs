using System.Text.RegularExpressions;

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
