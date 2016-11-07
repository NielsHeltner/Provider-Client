using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.domain.page;

namespace Provider.db
{
    public interface IDatabase
    {
        bool GetLogin(string username, string password);

        List<Page> GetSuppliers();
    }
}
