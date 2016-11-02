using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public class Supplier : AbstractUser
    {
        public Supplier(string userName, string password) : base(userName, password)
        {
        }
    }
}
