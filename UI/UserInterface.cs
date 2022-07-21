using Core.Services;
using Helpers;
using MyBankApp.Core.Core;

namespace UI
{
    public class UserInterface
    {
        /// <summary>
        /// Method to display user interface
        /// </summary>
        public static void Process()
        {
        Main:
            Menus.MainMenu();
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Menus.LoginMenu();
            }
            else if (input == "2")
            {
                Menus.RegistrationMenu();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Profile Successfully Registered");
                Console.ResetColor();
                Menus.LoggedInMenu();
            }

            else if (input == "3")
            {
                LogOut.CustomerLogOut();
                Console.Read();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                goto Main;
            }
        }
    }
}