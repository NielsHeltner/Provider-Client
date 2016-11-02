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

        public Boolean Validate(String username, String password)
        {
            ///TODO: to be implementede
        }

        

    }
}
