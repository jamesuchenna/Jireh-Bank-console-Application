using Core.DataStore;
using MyBankApp.Core.Core;
using MyBankApp.Utility;

namespace Core.Services
{
    public class AccountService
    {
        /// <summary>
        /// Method for account balance check
        /// </summary>
        public static double CheckBalance(Account account)
        {
            return account.Balance;
        }

        /// <summary>
        /// Method for account deposit
        /// </summary>
        public static void Deposit(double amount, Account account)
        {
            if (amount > 0)
            {
                account.Balance += amount;

                Transaction.TransactionIdCount++;
                Transaction transaction = new Transaction()
                {
                    TransactionId = Transaction.TransactionIdCount,
                    Amount = amount,
                    AccountId = account.Id,
                    Balance = account.Balance,
                    AccountType = account.Type,
                    Description = $"Money deposited",
                    Date = DateTime.Now,
                    Category = "Credit"
                };
                account.Transactions.Add(transaction);
            }
        }

        /// <summary>
        /// Method for account withdrawal
        /// </summary>
        public static bool Withdrawal(double amount, Account account)
        {
            if (account.Type == AccountType.Savings)
            {
                if (account.Balance - amount >= 1000)
                {
                    account.Balance -= amount;

                    Transaction.TransactionIdCount++;
                    Transaction transaction = new Transaction()
                    {
                        TransactionId = Transaction.TransactionIdCount,
                        Amount = amount,
                        AccountId = account.Id,
                        Balance = account.Balance,
                        AccountType = account.Type,
                        Description = $"Money withdrawn",
                        Date = DateTime.Now,
                        Category = "Debit"
                    };
                    account.Transactions.Add(transaction);
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient balance! Try again");
                    Console.ResetColor();
                    Console.ReadLine();
                    return false;
                }
            }

            if (account.Type == AccountType.Current)
            {
                if (account.Balance - amount >= 0)
                {
                    account.Balance -= amount;
                    Transaction.TransactionIdCount++;

                    Transaction transaction = new Transaction()
                    {
                        TransactionId = Transaction.TransactionIdCount,
                        Amount = amount,
                        AccountId = account.Id,
                        Balance = account.Balance,
                        AccountType = account.Type,
                        Description = $"Money withdrawn",
                        Date = DateTime.Now,
                        Category = "Credit"
                    };
                    account.Transactions.Add(transaction);
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient balance! Try again");
                    Console.ResetColor();
                    Console.ReadLine();
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Method for account Transfer
        /// </summary>
        public static void Transfer(double amount, Account sender, string dest)
        {
            foreach (var account in Data.Accounts)
            {
                if (account.AccountNumber == dest)
                {
                    sender.Balance -= amount;
                    Transaction.TransactionIdCount++;

                    Transaction transaction = new Transaction()
                    {
                        TransactionId = Transaction.TransactionIdCount,
                        Amount = amount,
                        AccountId = sender.Id,
                        Balance = sender.Balance,
                        AccountType = sender.Type,
                        Description = $"Money sent to {dest}",
                        Date = DateTime.Now,
                        Category = "Debit"
                    };
                    sender.Transactions.Add(transaction);

                    account.Balance += amount;

                    Transaction transaction1 = new Transaction()
                    {
                        TransactionId = Transaction.TransactionIdCount,
                        AccountId = account.Id,
                        Balance = account.Balance,
                        AccountType = account.Type,
                        Amount = amount,
                        Description = $"Received from {sender.AccountNumber}",
                        Category = "Credit",
                        Date = DateTime.Now
                    };
                    account.Transactions.Add(transaction1);
                }
            }
        }
    }
}
