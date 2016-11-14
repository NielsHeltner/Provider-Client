using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using Provider.domain.bulletinboard;
using IO.Swagger.Api;

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
        }

        private Controller()
        {
            userManager = new UserManager();
            pageManager = new PageManager();
            bulletinboard = new Bulletinboard();
            LoginApi api = new LoginApi("http://10.126.13.11:8080");
            IO.Swagger.Model.User user = api.LogIn("Niclas", "Antonio");
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

        public User GetLoggedInUser()
        {
            return userManager.loggedInUser;
        }

        public List<Post> ViewAllPosts()
        {
            return bulletinboard.ViewAllPosts();
        }

        public List<Post> ViewWarningPosts()
        {
            return bulletinboard.ViewWarningPosts();
        }
        public List<Post> ViewRequestPosts()
        {
            return bulletinboard.ViewRequestPosts();
        }
        public List<Post> ViewOfferPosts()
        {
            return bulletinboard.ViewOfferPosts();
        }

        public void CreatePost(String owner, string title, string description, Post.Types type)
        {
            bulletinboard.CreatePost(owner, title, description, type);
        }

        public void DeletePost(Post post)
        {
            bulletinboard.DeletePost(post);
        }

        public void EditPost(Post post, string newDescription, string newTitle)
        {
            bulletinboard.EditPost(post, newDescription, newTitle);
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
