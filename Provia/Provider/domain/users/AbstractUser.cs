using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public abstract class AbstractUser
    {
        public string userName { get; private set; }

        public string password { get; private set; }

        public AbstractUser(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public int getRights()
        {
            return 1;
        }

    }
}
