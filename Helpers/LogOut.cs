using Core.DataStore;

namespace Helpers
{
    public class LogOut
    {
        /// <summary>
        /// Method responsible for logging out
        /// </summary>
        public static void CustomerLogOut()
        {
            Data.currentUser = null;
        }
    }
}
