using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using Provider.domain.bulletinboard;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;
        private Bulletinboard bulletinboard;
        private ControllerApi api;

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
            api = new ControllerApi("http://10.126.13.189:8080");
            //api = new ControllerApi("http://tek-sb3-glo0a.tek.sdu.dk:8080");
            //userManager.loggedInUser;
        }

        public List<IO.Swagger.Model.Page> GetPages()
        {
            return api.GetSupplier();
            //return pageManager.pages;
        }
        
        public bool LogIn(string userName, string password)
        {

            try
            {
                IO.Swagger.Model.User user = api.Validate(userName, password);
                if (user != null)
                {
                    userManager.loggedInUser = new User(user.Username, password, User.Rights.Admin);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ApiException e)
            {
                return false;
                //e.printStackTrace();
            }
            //return userManager.Validate(userName, password);
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
