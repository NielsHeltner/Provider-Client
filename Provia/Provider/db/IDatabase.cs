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
        List<Product> GetProducts(string supplier);
        void AddNote(string supplierName, Note note);
        void UpdateNote(string supplierName, Note note);
    }
}
