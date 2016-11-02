using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public class Admin : AbstractUser
    {
        public Admin(string userName, string password) : base(userName, password)
        {
        }
    }
}
