using MyBankApp.Utility;
using Utility.Interface;

namespace MyBankApp.Core.Core
{
    /// <summary>
    /// Method contains fields for the account
    /// </summary>
    public class Account : IAccount
    {
        public static int IdCount = 0;
        public int Id { get; set; }
        public string AccountName { get ; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
