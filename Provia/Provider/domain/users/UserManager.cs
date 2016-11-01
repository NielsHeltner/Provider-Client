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

        private AbstractUser LoggedInUser { get; set; }
        

        public Boolean Validate(String username, String password)
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
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
