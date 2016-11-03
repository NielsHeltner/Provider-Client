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
            pages = new List<Page>();
            Page p1 = new Page(new Supplier("Vitafit", "password1234"));
            p1.AddProduct(new Product(0, 100, "Sække", "VitaMere", new DateTime(2017, 01, 20, 22, 30, 00)));
            p1.AddProduct(new Product(0, 100, "Spande", "VitaMindre", new DateTime(2017, 01, 18, 16, 15, 00)));
            p1.AddProduct(new Product(0, 100, "Plastik", "VitaNice", new DateTime(2016, 12, 22, 06, 05, 00)));

            Page p2 = new Page(new Supplier("B2Vitas", "password1234"));
            p2.AddProduct(new Product(0, 100, "Paller", "Tiamin", new DateTime(2017, 02, 01, 22, 30, 00)));
            p2.AddProduct(new Product(0, 100, "Spande", "Biotin", new DateTime(2016, 12, 02, 09, 15, 00)));
            p2.AddProduct(new Product(0, 100, "Plastik", "Fyllokinon", new DateTime(2016, 11, 23, 11, 45, 00)));

            Page p3 = new Page(new Supplier("ProteinVitmins", "password1234"));
            p3.AddProduct(new Product(0, 100, "Maxi Palle", "VitaMonster", new DateTime(2017, 03, 15, 03, 30, 00)));
            p3.AddProduct(new Product(0, 100, "Spande", "Niacin", new DateTime(1994, 06, 01, 03, 34, 00)));
            p3.AddProduct(new Product(0, 100, "Container", "Appelsiner", new DateTime(2016, 11, 30, 11, 45, 00)));

            pages.Add(p1);
            pages.Add(p2);
            pages.Add(p3);
        }

        /// <summary>
        /// Returns a suppliers page
        /// </summary>
        /// <param name="supplier">The name of the suppliers page that should</param>
        /// <returns>Returns a specific suppliers page</returns>
        public Page GetSupplierPage(Supplier supplier)
        {
            return pages.Find(page => page.owner.Equals(supplier));
        }
    }
}
