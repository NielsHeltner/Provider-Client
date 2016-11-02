using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public abstract class AbstractUser
    {
        public String userName { get; private set; }

        public String password { get; private set; }

    }
}
