namespace MyBankApp.Core
{
    interface ICustomer
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string FullName { get; set; }
        int Id { get; set; }
        bool IsLoggedIn { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
    }
}