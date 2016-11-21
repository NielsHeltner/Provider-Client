using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<IO.Swagger.Model.Page> pages { get; set; }

        public PageManager()
        {
            
        }        

        public List<Page> Search(string searchTerm)
        {
            HashSet<Page> results = new HashSet<Page>();
            pages.AsParallel().ForAll(page =>
            {
                if (page.Owner.ToLower().Contains(searchTerm.ToLower()))
                {
                    results.Add(page);
                }
                page.Products.AsParallel().ForAll(product =>
                {
                    if (product.ProductName.ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(page);
                    }
                });
            });
            return results.ToList();
        }
    }
}
