using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    interface IUserManager
    {

        bool Validate(string userName, string password);

    }
}
