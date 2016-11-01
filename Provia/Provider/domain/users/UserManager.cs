using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    class UserManager
    {
        private HashSet<AbstractUser> users;

        private AbstractUser loggedInUser { get; set; }
        

        public Boolean validate(String username, String password)
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
        }
    }
}
