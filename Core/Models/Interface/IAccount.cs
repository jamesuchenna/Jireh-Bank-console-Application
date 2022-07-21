using MyBankApp.Core.Core;
using MyBankApp.Utility;

namespace Utility.Interface
{
    interface IAccount
    {
        public static int IdCount = 0;
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public static List<Transaction> Transactions { get; set; }
    }
}