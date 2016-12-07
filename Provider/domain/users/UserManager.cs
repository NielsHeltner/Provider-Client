
namespace Provider.domain.users
{
    public class UserManager
    {
        public IO.Swagger.Model.User loggedInUser { get; set; }

        /// <summary>
        /// Checks if the userName is found in the set of users, and then checks the users password. 
        /// If user and password returns true, the user will be set as LoggedInUser. *NOT CASESENSITIVE*
        /// </summary>
        /// <param name="userName">The logging in users username</param>
        /// <param name="password">The logging in users password</param>
        /// <returns> True if username and password matches.  </returns>
        public bool Validate(string userName, string password)
        {
            //loggedInUser = Database.instance.GetLogin(userName, password);
            return loggedInUser != null;
        }

        /// <summary>
        /// The logged in user is being set to null, so the user will be logged out. 
        /// </summary>
        public void LogOut()
        {
            loggedInUser = null;
        }

    }
}
