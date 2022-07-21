using System.Text.RegularExpressions;

namespace Helpers
{
    public class Validate
    {
        /// <summary>
        /// Method to handle password validation
        /// </summary>
        public static bool PasswordChecker(string password)
        {
            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
            return RegularExpCheck(passwordRegex, password);
        }

        /// <summary>
        /// Method to handle Email validation
        /// </summary>
        public static bool EmailChecker(string email)
        {
            string emailRegex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return RegularExpCheck(emailRegex, email);

        }

        /// <summary>
        /// Method to handle name validation
        /// </summary>
        public static bool NameChecker(string name)
        {
            string nameRegex = @"^[A-Z]";
            return RegularExpCheck(nameRegex, name);
        }

        /// <summary>
        /// Method to handle phone validation
        /// </summary>
        public static bool PhoneChecker(string phone)
        {
            string phoneRegex = @"^\+?[0-9]{3}-?[0-9]{6,12}$";
            return RegularExpCheck(phoneRegex, phone);
        }

        /// <summary>
        /// Method for regular experssions
        /// </summary>
        private static bool RegularExpCheck(string code, string input)
        {
            Regex exp = new Regex(code);

            if (exp.IsMatch(input)) return true;
            return false;
        }
    }
}
