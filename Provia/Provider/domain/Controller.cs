using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;

        public static IController instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
            private set
            {

            }
        }

        private Controller()
        {
            userManager = new UserManager();
            pageManager = new PageManager();
        }

        public List<Page> GetPages()
        {
            return pageManager.pages;
        }
        
        public bool LogIn(string userName, string password)
        {
            return userManager.Validate(userName, password);
        }

        public void LogOut()
        {
            userManager.LogOut();
        }

        public string GetLoggedInUser()
        {
            return userManager.loggedInUser.userName;
        }

        public void AddNoteToSupplier(string supplierName, string text)
        {
            pageManager.AddNoteToSupplier(supplierName, text);
        }
    }
}
