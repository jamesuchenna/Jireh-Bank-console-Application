using Core.DataStore;
using MyBankApp.Core;

namespace Helpers
{
    public class Login
    {
        /// <summary>
        /// Method to authenticate customer's login
        /// </summary>
        public static bool CustomerLogin(string userEmail, string userPassword)
        {
            foreach (var user in Data.Customer)
            {
                if (user.Email == userEmail && user.Password == userPassword)
                {
                    Data.currentUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}