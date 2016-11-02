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
