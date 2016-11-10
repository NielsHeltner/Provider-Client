using Provider.db;

namespace Provider.domain.users
{
    public class UserManager
    {
        public AbstractUser loggedInUser { get; private set; }

        /// <summary>
        /// Checks if the userName is found in the set of users, and then checks the users password. 
        /// If user and password returns true, the user will be set as LoggedInUser. *NOT CASESENSITIVE*
        /// </summary>
        /// <param name="userName">The logging in users username</param>
        /// <param name="password">The logging in users password</param>
        /// <returns> True if username and password matches.  </returns>

        public bool Validate(string userName, string password)
        {
            if(Database.instance.GetLogin(userName, password))
            {
                loggedInUser = new Provia(userName, password);
                return true;
                
            }
            return false;
        }

        /// <summary>
        /// logs out the current logged in user.
        /// </summary>
        public void LogOut()
        {
            loggedInUser = null;
        }

    }
}
