using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public class UserManager
    {
        private HashSet<AbstractUser> users;

        public AbstractUser LoggedInUser { get; private set; }

        public UserManager()
        {
            users = new HashSet<AbstractUser>();
            users.Add(new Provia("Jebisan", "123"));
        }

        /// <summary>
        /// Checks if the userName is found in the set of users, and then checks the users password. 
        /// If user and password returns true, the user will be set as LoggedInUser. *NOT CASESENSITIVE*
        /// </summary>
        /// <param name="userName">The logging in users username</param>
        /// <param name="password">The logging in users password</param>
        /// <returns> True if username and password matches.  </returns>

        public bool Validate(string userName, string password)
        {
            foreach(AbstractUser user in users)
            {
               if(userName.Equals(user.userName))
                {
                    if(password.Equals(user.password))
                    {
                        LoggedInUser = user;
                        return true;
                    }
                }
            }
            return false;
        }

        public void LogOut()
        {
            LoggedInUser = null;

        }

    }
}
