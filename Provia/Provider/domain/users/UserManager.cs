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
            foreach(AbstractUser a in users)
            {
               if(username == a.userName)
                {
                    if(password == a.password)
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
            foreach(AbstractUser a in users)
            {
                if(a.GetType() == typeof(Supplier)){
                    suppliers.Add((Supplier) a);
                }
                        
            }
            return suppliers;
        }

    }
}
