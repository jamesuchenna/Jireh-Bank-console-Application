using MyBankApp.Core.Core;

namespace Helpers
{
    public class PrintTable
    {
        /// <summary>
        /// Method to display account details header
        /// </summary>
        public static void AccountViewHeader()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------ACCOUNT DETAILS--------------------------------\n\n");
            Console.ResetColor();
            Console.WriteLine("=======================================================================================");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|{" S/N",-2} |{"        FULL NAME",-25} |{" ACCOUNT NUMBER",-15} |{"ACCOUNT TYPE",-10} |{"        AMOUNT",-20:N0} |");
            Console.ResetColor();
            Console.WriteLine("=======================================================================================");

        }

        /// <summary>
        /// Method to display list of customer's account
        /// </summary>
        public static void CustomerAccountViewDetails(List<Account> accounts)
        {
            int index = accounts.Count;
            for (int i = 0; i < index; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"|  {i + 1,-2} |     {accounts[i].AccountName,-20} |   {accounts[i].AccountNumber,-12} |   {accounts[i].Type,-9} |        {accounts[i].Balance,-12:N0} |");
            }
            Console.ResetColor();
            Console.WriteLine("=======================================================================================");
        }

        /// <summary>
        /// Method to display transaction details header
        /// </summary>
        public static void TransactionViewHeader()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ACCOUNT TRANSACTIONS DETAILS\n\n");
            Console.ResetColor();
            Console.WriteLine("====================================================================================================");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|{"          DATE",-20} |{"          DESCRIPTION",-30} |{"       AMOUNT",-20}  |{"       BALANCE",-20} |");
            Console.ResetColor();
            Console.WriteLine("====================================================================================================");
        }

        /// <summary>
        /// Method to display list of customer's transactions
        /// </summary>
        public static void TransactionViewDetails(Account account)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (Transaction transactions in account.Transactions)
            {
                Console.WriteLine($"| { transactions.Date,-10} |      { transactions.Description,-24} |       { transactions.Amount,-15:N0}|     { transactions.Balance,-15:N0} |");
            }
            Console.ResetColor();
            Console.WriteLine("====================================================================================================");
        }
    }
}
