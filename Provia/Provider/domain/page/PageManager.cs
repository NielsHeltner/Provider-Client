using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; private set; }

        public PageManager()
        {
            List<Page> pageList = new List<Page>();
            Page VitaFit = new Page();
            Page B2Vitas = new Page();
            Page ProteinVita = new Page();
            pageList.Add(new Page());
            pageList.Add(new Page());
            pageList.Add(new Page());
            pages = pageList;
        }
        
        /// <summary>
        /// Returns a suppliers page
        /// </summary>
        /// <param name="supplier">The name of the suppliers page that should</param>
        /// <returns>Returns a specifik suppliers page</returns>
        public Page GetSupplierPage(Supplier supplier)
        {
            return pages.Find(x => x.owner.Equals(supplier));
        }

        
    }
}
