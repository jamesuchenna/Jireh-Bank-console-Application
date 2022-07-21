using Core.DataStore;
using MyBankApp.Core;
using MyBankApp.Core.Core;
using MyBankApp.Utility;

namespace Core.Services
{
    public class CustomerService
    {
        /// <summary>
        /// Method for account creation
        /// </summary>
        public static void CreateAccount(double firstDep, int accountType, Customer customer)
        {
            var account = new Account()
            {
                AccountName = customer.FullName,
                AccountNumber = RandomNum(8),
                Type = accountType == 1 ? AccountType.Savings : AccountType.Current,
                Balance = firstDep,
                CustomerId = customer.Id,
                IsActive = true
            };
            Data.Accounts.Add(account);
            customer.Accounts.Add(account);

            Transaction.TransactionIdCount++;
            Transaction transaction = new Transaction()
            {
                TransactionId = Transaction.TransactionIdCount,
                Amount = firstDep,
                AccountId = account.Id,
                Balance = account.Balance,
                AccountType = account.Type,
                Description = $"Initial deposit",
                Date = DateTime.Now,
                Category = "Credit"
            };
            account.Transactions.Add(transaction);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------ACCOUNT CREATED--------------------------------\n\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Congratulations!\nYour {account.Type} account Number is : {account.AccountNumber}\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Method for account number generation
        /// </summary>
        private static string RandomNum(int count)
        {
            var randomNum = new Random();
            string num = "01";
            for (int i = 0; i < count; i++)
                num = String.Concat(num, randomNum.Next(10).ToString());
            return num;
        }
    }
}
