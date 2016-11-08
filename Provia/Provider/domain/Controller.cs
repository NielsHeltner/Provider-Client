using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.domain.bulletinboard;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;
        private Bulletinboard bulletinboard;

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
            bulletinboard = new Bulletinboard();
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

        public string GetLoggedInUserName()
        {
            return userManager.loggedInUser.userName;
        }

        public List<Post> ViewBulletinBoard(int type)
        {
            return bulletinboard.ViewBulletinBoard(type);
        }

        public void CreatePost(AbstractUser owner, string title, string description, int type)
        {
            bulletinboard.CreatePost(owner, title, description, type);
        }

        public void DeletePost(Post post)
        {
            bulletinboard.DeletePost(post);
        }

        public void EditPost(string editedText, Post post)
        {
            bulletinboard.EditPost(editedText, post);
        }

        public void AddNoteToSupplier(string supplierName, string text)
        {
            pageManager.AddNoteToSupplier(supplierName, text);
        }

        public List<Page> Search(string searchTerm)
        {
            return pageManager.Search(searchTerm);
        }
    }
}
