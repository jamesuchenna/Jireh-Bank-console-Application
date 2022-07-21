using MyBankApp.Core.Core;

namespace MyBankApp.Core
{
    /// <summary>
    /// Method contains fields for the customer
    /// </summary>
    public class Customer : ICustomer
    {
        public static int IdCount = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } set { } }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLoggedIn { get; set; }

        public List<Account> Accounts = new List<Account>();
    }
}
