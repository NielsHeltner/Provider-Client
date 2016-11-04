using System;
using System.Collections.Generic;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain
{
    public interface IController
    {
        List<Page> GetPages();

        bool LogIn(string userName, string password);

        void LogOut();

        string GetLoggedInUser();

        void AddNoteToSupplier(string supplierName, string text);
    }
}
