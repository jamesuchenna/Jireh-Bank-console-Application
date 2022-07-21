using Core.DataStore;
using MyBankApp.Core;

namespace Helpers
{
    public class Register
    {
        /// <summary>
        /// Method to handle customer's registration
        /// </summary>
        public static void RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            if (Validate.PasswordChecker(password) && Validate.EmailChecker(email) && Validate.NameChecker(lastName) && Validate.NameChecker(lastName) && Validate.PhoneChecker(phoneNumber))
            {
                Customer.IdCount++;
                Customer customer = new Customer()
                {
                    Id = Customer.IdCount,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password,
                    PhoneNumber = phoneNumber,
                };

                Data.Customer.Add(customer);
                Login.CustomerLogin(email, password);
            }
            else Console.WriteLine("invalid details");
        }
    }
}
