using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.domain.Bulletinboard;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;
        private Provider.domain.Bulletinboard.Bulletinboard bulletinboard;

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
            bulletinboard = new Provider.domain.Bulletinboard.Bulletinboard();
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

        public List<Post> ViewBulletinBoard(int type)
        {
            return bulletinboard.ViewBulletinBoard(type);
        }
    }
}
