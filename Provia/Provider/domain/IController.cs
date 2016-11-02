using System;
using System.Collections.Generic;
using System.Linq;
using Provider.domain.page;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain
{
    public interface IController
    {

         List<Page> ViewSuppliers();
    }
}
