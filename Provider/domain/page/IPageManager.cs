using System.Collections.Generic;
using IO.Swagger.Model;

namespace Provider.domain.page
{
    public interface IPageManager
    {

        List<Page> pages { get; set; }

        List<Page> Search(string searchTerm);

    }
}