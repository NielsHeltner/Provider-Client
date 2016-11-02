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
        
        public UserManager()
        {
            users = new HashSet<AbstractUser>();
            users.Add(new Provia("Jebisan", "123"));
        }

        public bool Validate(String username, String password)
        {
            foreach (AbstractUser user in users)
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
            foreach(AbstractUser a in this.users)
            {
                if(a.GetType() == typeof(Supplier)){
                    suppliers.Add((Supplier) a);
                }
                        
            }

            return suppliers;
        }

    }
}
