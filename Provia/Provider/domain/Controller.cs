using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain
{
    class Controller
    {
        private static Controller instance;
        private UserManager userManager;
        private PageManager pageManager;

        public static Controller GetInstance()
        {
            if(instance == null)
            {
                instance = new Controller();                
            }           
                return instance;        
        }
        public List<Supplier> ViewSuppliers()
        {
            return userManager.GetSuppliers();
        }

        public Page GetSupplierPage(Supplier s)
        {
            return pageManager.GetSupplierPage(s);
        }
        
        public Boolean Login(String name, String password)
        {
            return userManager.Validate(name, password);
        }
    }
}
