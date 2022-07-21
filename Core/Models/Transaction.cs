using MyBankApp.Utility;

namespace MyBankApp.Core.Core
{
    /// <summary>
    /// Method contains fields for the transactions
    /// </summary>
    public class Transaction : ITransaction
    {
        public static int TransactionIdCount = 0;
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public double Balance { get; set; }
        public double Amount { get; set; }
        public AccountType AccountType { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
