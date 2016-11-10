using System.Collections.Generic;
using System.Linq;
using Provider.db;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; }

        public PageManager()
        {
            pages = Database.instance.GetSuppliers();
            foreach(Page supplierPage in pages)
            {
                supplierPage.AddProduct(Database.instance.GetProducts(supplierPage.owner));
            }
        }

        /// <summary>
        /// Returns a suppliers page
        /// </summary>
        /// <param name="supplier">The name of the suppliers page that should</param>
        /// <returns>Returns a specific suppliers page</returns>
        private Page GetSupplierPage(string supplierName)
        {
            return pages.Find(page => page.owner.Equals(supplierName));
        }

        public void AddNoteToSupplier(string supplierName, string text)
        {
            if(GetSupplierPage(supplierName).note == null)
            {
                GetSupplierPage(supplierName).note = new Note(text);
                Database.instance.AddNote(supplierName, GetSupplierPage(supplierName).note);
            }
            else
            {
                GetSupplierPage(supplierName).note.text = text;
                Database.instance.UpdateNote(supplierName, GetSupplierPage(supplierName).note);
            }
        }

        public List<Page> Search(string searchTerm)
        {
            HashSet<Page> results = new HashSet<Page>();
            lock (pages)
            {
                pages.AsParallel().ForAll(page =>
                {
                    if (page.owner.ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(page);
                    }
                    page.products.AsParallel().ForAll(product =>
                    {
                        if (product.productName.ToLower().Contains(searchTerm.ToLower()))
                        {
                            results.Add(page);
                        }
                    });
                });
            }
            return results.ToList();
        }
    }
}
