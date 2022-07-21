using MyBankApp.Core;
using MyBankApp.Core.Core;

namespace Core.DataStore
{
    /// <summary>
    /// This method Serves as the data base
    /// </summary>
    public static class Data
    {
        public static Customer currentUser { get; set; }
        public static List<Customer> Customer { get; set; } = new List<Customer>();
        public static List<Account> Accounts { get; set; } = new List<Account>();
    }
}
