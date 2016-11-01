using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    class UserManager
    {
        public AbstractUser loggedInUser { get; set; }
        

        public Boolean validate(String username, String password)
        {
            ///TODO
            throw new NotImplementedException();
        }
    }
}
