using IO.Swagger.Model;

namespace Provider.domain.users
{
    public class UserManager : IUserManager
    {
        public User loggedInUser { get; set; }

        /// <summary>
        /// The logged in user is being set to null, meaning the user will be logged out. 
        /// </summary>
        public void LogOut()
        {
            loggedInUser = null;
        }

    }
}
