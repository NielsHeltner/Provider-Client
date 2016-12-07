using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; set; }  
        /// <summary>
        /// Searches through all suppliers and products with a given search term. 
        /// </summary>
        /// <param name="searchTerm">The term which is being searched on</param>
        /// <returns> A list with searchresults </returns>
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

            return results.Keys.ToList();
        }
    }
}
