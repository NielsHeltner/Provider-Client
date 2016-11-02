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
