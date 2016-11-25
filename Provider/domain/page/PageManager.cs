using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; set; }  

        public List<Page> Search(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            ConcurrentDictionary<Page, byte> results = new ConcurrentDictionary<Page, byte>();
            pages.AsParallel().ForAll(page =>
            {
                if (page.Owner.ToLower().Contains(searchTerm))
                {
                    results.GetOrAdd(page, new byte());
                }
                page.Products.AsParallel().ForAll(product =>
                {
                    if (product.ProductName.ToLower().Contains(searchTerm))
                    {
                        results.GetOrAdd(page, new byte());
                    }
                });
            });
            /*List<Page> results = pages.AsParallel()
                                    .Where(page => page.Owner.ToLower().Contains(searchTerm))
                                    .ForAll(page => page.Products.AsParallel()
                                                                .Where(product => product.ProductName.ToLower().Contains(searchTerm)));*/
            return results.Keys.ToList();
        }
    }
}
