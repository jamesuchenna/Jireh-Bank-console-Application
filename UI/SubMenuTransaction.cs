using Core.DataStore;
using Core.Services;
using Helpers;
using MyBankApp.Core.Core;

namespace UI
{
    public class SubMenuTransaction
    {
        /// <summary>
        /// Method to display Customer's dash board for transactions
        /// </summary>
        public static void TransactionMenu(Account account)
        {
        sub:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------DASH BOARD--------------------------------\n\n");
            Console.ResetColor();

            Console.WriteLine("1. Check Balance\n2. Withdrawal\n3. Deposit\n" +
                "4. Transfer\n5. Statement of account\n6. Previous\n");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    AccountService.CheckBalance(account);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------VIEW BALANCE--------------------------------\n\n");
                    Console.ResetColor();
                    Console.WriteLine($"Your account balance is: {account.Balance:N0}");
                    Console.Read();
                    goto sub;
                    break;
                case "2":
                withdraw:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------WITHDRAWAL--------------------------------\n\n");
                    Console.ResetColor();
                    Console.Write("How much do you want to withdraw: ");
                    double cash;
                    bool checkInit = double.TryParse(Console.ReadLine(), out cash);
                    if (checkInit && cash > 0)
                    {
                        AccountService.Withdrawal(cash, account);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You've successfully withdrawn {cash}");
                        Console.ReadLine();
                        goto sub;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid amount. Please enter a valid amount");
                        Console.ReadLine();
                        goto withdraw;
                        Console.ResetColor();
                    }
                    break;
                case "3":
                dep:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------DEPOSIT--------------------------------\n\n");
                    Console.ResetColor();
                    Console.Write("How much do you want to deposit: ");
                    double deposit;
                    bool checkDep = double.TryParse(Console.ReadLine(), out deposit);
                    if (checkDep && deposit > 0)
                    {
                        AccountService.Deposit(deposit, account);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successfull deposited {deposit}");
                        Console.Read();
                        goto sub;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid amount. Please enter a valid amount");
                        Console.ReadLine();
                        goto dep;
                        Console.ResetColor();
                    }
                    break;
                case "4":
                trans:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------TRANSFER--------------------------------\n\n");
                    Console.ResetColor();
                    Console.Write("Please enter the amount to transfer: ");
                    double amount;
                    bool checkTrans = double.TryParse(Console.ReadLine(), out amount);
                    if (checkTrans && amount > 0 && amount > 0 && account.Balance - amount > 0)
                    {
                    accInput:
                        Console.WriteLine("Enter receiver's bank account number");
                        var accNum = Console.ReadLine();
                        foreach (var accounts in Data.Accounts)
                        {
                            if (accNum == account.AccountNumber)
                            {
                                AccountService.Transfer(amount, account, accNum);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Successfully tranferred {amount} to {accNum}");
                                Console.ReadLine();
                                goto sub;
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid account number. Press 1 to retry or any key to exit");
                                Console.ResetColor();
                                var trial = Console.ReadLine();
                                if (trial == "1")
                                {
                                    goto accInput;
                                }
                                else
                                {
                                    goto sub;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid amount. Please enter a valid amount");
                        Console.ResetColor();
                        goto trans;
                    }
                    break;
                case "5":
                    PrintTable.TransactionViewHeader();
                    PrintTable.TransactionViewDetails(account);
                    Console.Read();
                    goto sub;
                    break;
                case "6":
                    Menus.LoggedInMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option! Try again");
                    goto sub;
            }
        }
    }
}
