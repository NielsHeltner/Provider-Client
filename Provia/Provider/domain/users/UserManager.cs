using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public class UserManager
    {
        private HashSet<AbstractUser> usersSet;

        public AbstractUser LoggedInUser { get; private set; }

        public UserManager()
        {
            usersSet = new HashSet<AbstractUser>();
            usersSet.Add(new Provia("Jebisan", "123"));
        }

        public Boolean Validate(String username, String password)
        {
            foreach(AbstractUser user in usersSet)
            {
               if(username.Equals(user.userName))
                {
                    if(password.Equals(user.password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            foreach(AbstractUser a in usersSet)
            {
                if(a.GetType() == typeof(Supplier)){
                    suppliers.Add((Supplier) a);
                }
                        
            }
            return suppliers;
        }

    }
}
