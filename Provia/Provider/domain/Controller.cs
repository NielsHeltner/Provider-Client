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

        public Controller GetInstance()
        {
            if(instance == null)
            {
                instance = new Controller();                
            }           
                return instance;        
        }
        public List<Supplier> ViewSuppliers()
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
        }

        public Page GetSupplierPage(Supplier s)
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
        }

        public Boolean Login(String Name, String Password)
        {
            ///TODO: to be implementede
            throw new NotImplementedException();
        }
    }
}
