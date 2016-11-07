using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.db;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; private set; }

        public PageManager()
        {
            /*pages = new List<Page>();
            Page p1 = new Page(new Supplier("Vitafit", "password1234"));
            p1.AddProduct(new Product(0, "VitaMere", "Mega lækkert vitamin", 100, "Sække", "C3-P0", 2.5, new DateTime(2017, 01, 20, 22, 30, 00)));
            p1.AddProduct(new Product(1, "VitaMindre", "Smager udemærket", 210, "Spande", "D2-H1", 1.3, new DateTime(2017, 01, 18, 16, 15, 00)));
            p1.AddProduct(new Product(2, "VitaNice", "Lugter fint", 120, "Plastik", "H2O", 1.2, new DateTime(2016, 12, 22, 06, 05, 00)));

            Page p2 = new Page(new Supplier("B2Vitas", "password1234"));
            p2.AddProduct(new Product(3, "VitaMonster", "Er gennemsigtig", 312, "Maxi Palle", "O3-J5", 7.5, new DateTime(2017, 03, 15, 03, 30, 00)));
            p2.AddProduct(new Product(4, "Niacin", "Er meget tungt", 50, "Spande", "U7-2", 100.4, new DateTime(1994, 06, 01, 03, 34, 00)));
            p2.AddProduct(new Product(5, "VitaNice", "Lugter fint", 120, "Plastik", "H2O", 1.2, new DateTime(2016, 12, 22, 06, 05, 00)));

            Page p3 = new Page(new Supplier("ProteinVitmins", "password1234"));
            p3.AddProduct(new Product(6, "VitaMonster", "Er gennemsigtig", 312, "Maxi Palle", "O3-J5", 7.5, new DateTime(2017, 03, 15, 03, 30, 00)));
            p3.AddProduct(new Product(7, "Niacin", "Er meget tungt", 50, "Spande", "U7-2", 100.4, new DateTime(1994, 06, 01, 03, 34, 00)));
            p3.AddProduct(new Product(8, "Appelsiner", "Er orange", 5, "Container", "4P-LSIN", 3.7, new DateTime(2016, 11, 30, 11, 45, 00)));

            pages.Add(p1);
            pages.Add(p2);
            pages.Add(p3);
            */
            pages = Database.instance.GetSuppliers();
        }

        /// <summary>
        /// Returns a suppliers page
        /// </summary>
        /// <param name="supplier">The name of the suppliers page that should</param>
        /// <returns>Returns a specific suppliers page</returns>
        private Page GetSupplierPage(string supplierName)
        {
            return pages.Find(page => page.owner.userName.Equals(supplierName));
        }

        public void AddNoteToSupplier(string supplierName, string text)
        {
            if(GetSupplierPage(supplierName).note == null)
            {
                GetSupplierPage(supplierName).note = new Note(text);
            }
            else
            {
                GetSupplierPage(supplierName).note.text = text;
            }
        }

        public List<Page> Search(string searchTerm)
        {
            List<Page> results = new List<Page>();
            foreach (Page page in pages)
            {
                if(page.name.ToLower().Contains(searchTerm.ToLower()))
                {
                    results.Add(page);
                }
            }
            return results;
        }
    }
}
