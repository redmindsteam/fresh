using System.Text.RegularExpressions;

namespace Fresh.Service.Helpers
{
    public static class PasswordAttribute
    {
        public static string ValidationScore(this string password)
        {
            if (password.Length < 8 || password.Length > 18)
                return "Password must be at least 8 characters and maximum 16 characters";
            else if (new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$").IsMatch(password))
                return "Medium";
            else if (new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,18}$").IsMatch(password))
                return "Strong";
            else
                return "Password must contain at least one uppercase letter,one number and one special character($!%*?&)";
        }
    }
}
