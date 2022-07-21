using MyBankApp.Utility;

namespace MyBankApp.Core.Core
{
    interface ITransaction
    {
        int AccountId { get; set; }
        AccountType AccountType { get; set; }
        double Balance { get; set; }
        double Amount { get; set; }
        string Category { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
    }
}