using Helpers;
using Core.Services;
using Core.DataStore;

namespace UI
{
    public class Menus
    {
        /// <summary>
        /// Method to display Main interface
        /// </summary>
        public static void MainMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------WELCOME TO JIREH BANK--------------------------------\n\n");
            Console.ResetColor();
            Console.WriteLine("1. Old User \n2. New User \n3. Exit\n");
            Console.Write("Select an option: ");
        }

        /// <summary>
        /// Method to display Registration interface
        /// </summary>
        public static void RegistrationMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------REGISTRATION--------------------------------\n\n");
            Console.ResetColor();
            Console.WriteLine("Fill in the following details accordingly\n");
            Console.ResetColor();

            string firstName = "";
            string lastName = "";
            string email = "";
            string password = "";
            string phoneNumber = "";

            bool invalid = true;
            while (invalid)
            {
                Console.Write("Enter your first name: ");
                firstName = Console.ReadLine();
                if (Validate.NameChecker(firstName))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid. Name must Start with capital letter");
                    Console.ResetColor();
                }
            }
            while (invalid)
            {
                Console.Write("Enter your Last name: ");
                lastName = Console.ReadLine();
                if (Validate.NameChecker(lastName))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid. Name must Start with capital letter");
                    Console.ResetColor();
                }
            }
            while (invalid)
            {
                Console.Write("Enter your Email: ");
                email = Console.ReadLine();
                if (Validate.EmailChecker(email))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid email format");
                    Console.ResetColor();
                }
            }
            while (invalid)
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                if (Validate.PasswordChecker(password))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password must be six characters minimum\ncapital letters, digit and special characters inlusive");
                    Console.ResetColor();
                }
            }
            while (invalid)
            {
                Console.Write("Enter your phone number: ");
                phoneNumber = Console.ReadLine();
                if (Validate.PhoneChecker(phoneNumber) && phoneNumber.Length >9 && phoneNumber.Length < 13)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a valid phone number");
                    Console.ResetColor();
                }


            }
            Register.RegisterUser(firstName, lastName, email, password, phoneNumber);
        }

        /// <summary>
        /// Method to display Login interface
        /// </summary>
        public static void LoginMenu()
        {
        Login:
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------LOGIN--------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Enter your details to login\n\n");

            Console.Write("Enter your Email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Login.CustomerLogin(email, password);
            if (Login.CustomerLogin(email, password))
            {
                LoggedInMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Invalid Credentials\nPress 1 to try again or any key to go back");
                Console.ResetColor();
                var t = Console.ReadLine();
                Console.Clear();
                if (t == "1")
                {
                    goto Login;
                }
                else
                    UserInterface.Process();
            }
        }

        /// <summary>
        /// Method to display successful login interface
        /// </summary>
        public static void LoggedInMenu()
        {
        LoggedMenu:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"--------------------------------JIREH BANK--------------------------------\n\n");
            Console.ResetColor();

            var accounts = Data.currentUser.Accounts;

            Console.WriteLine("1. View Accounts\n2. Create account\n3. LogOut\n");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            if (option == "1")
            {
                Console.Clear();
                PrintTable.AccountViewHeader();
                PrintTable.CustomerAccountViewDetails(accounts);

                Console.Write("Select an account option: ");
                var selected = Console.ReadLine();
                int.TryParse(selected, out int number);

                if (number > 0 && number <= accounts.Count)
                {
                    var account = accounts[number - 1];
                    SubMenuTransaction.TransactionMenu(account);
                }
                else
                {
                    goto LoggedMenu;
                }
            }
            else if (option == "2")
            {
                Menus.CreateAccountMenu();
            }
            else if (option == "3")
            {
                Console.Clear();
                LogOut.CustomerLogOut();
                UserInterface.Process();
                Console.ReadLine();
            }
            else goto LoggedMenu;
        }

        /// <summary>
        /// Method to display Account creation interface
        /// </summary>
        public static void CreateAccountMenu()
        {
            double init;
            int accountType;
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------ACCOUNT CREATION--------------------------------\n\n");
                Console.ResetColor();
                Console.WriteLine("Choose type of account or any key to go back\n");

                Console.WriteLine("1. Savings\n2. Current\n");
                Console.Write("Select an option: ");

                bool checkType = int.TryParse(Console.ReadLine(), out accountType);
                if (checkType)
                {
                    break;
                }
                LoggedInMenu();
            }
            while (true)
            {
                Console.Write("Kindly open with an initial deposit of 1,000: ");
                bool checkInit = double.TryParse(Console.ReadLine(), out init);
                if (checkInit && init >= 1000)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Amount cannot be less than 1,000 minimum");
                Console.ResetColor();
            }
            CustomerService.CreateAccount(init, accountType, Data.currentUser);
            Console.Write("Press 1 to continue: ");
        input:
            var select = Console.ReadLine();
            if (select == "1")
            {
                LoggedInMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter a valid option: ");
                Console.ResetColor();
                goto input;
            }
        }
    }
}
