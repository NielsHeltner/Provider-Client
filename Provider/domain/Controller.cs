using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Provider.domain.bulletinboard;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;
        private Bulletinboard bulletinboard;
        private ControllerApi api;
        private List<string> files = new List<string>();
        private Object updateLock = new Object();

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
            //api = new ControllerApi("http://10.126.12.179:8080");
            //api = new ControllerApi("http://127.0.0.1:8080");
            //api = new ControllerApi("http://tek-sb3-glo0a.tek.sdu.dk:8080");
            api = new ControllerApi("http://192.168.1.234:8080");
            //api = new ControllerApi("http://192.168.1.234:8080");
            Update();
        }

        private void Update()
        {
            new Thread(() =>
            {
                try
                {
                    while ((bool) api.RequestUpdate())
                    {
                        lock (updateLock)
                        {
                            //GetSuppliers();
                            //ViewAllPosts();
                            bulletinboard.posts = api.GetAllPosts();
                            Monitor.PulseAll(updateLock);
                        }
                    }
                }
                catch (ApiException e)
                {
                    Update();
                }
            }).Start();
        }

        public Object GetUpdateLock()
        {
            return updateLock;
        }
        
        /// <summary>
        /// Skal logge brugeren ind. Kontrollerer først med Validate() metoden, som returnerer en bruger. 
        /// Den bruger bliver sat til loggedInUser, og så indlæses alle leverandører og opslag.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LogIn(string userName, string password)
        {
            User user = api.Validate(userName, password);
            if (user != null)
            {
                userManager.loggedInUser = user;
                GetSuppliers();
                GetPosts();
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            userManager.LogOut();
        }

        public User GetLoggedInUser()
        {
            return userManager.loggedInUser;
        }

        public void GetSuppliers()
        {
            pageManager.pages = api.GetSuppliers();
        }

        public List<Page> GetPages()
        {
            return pageManager.pages;
        }

        public void GetPosts()
        {
            bulletinboard.posts = api.GetAllPosts();
        }

        public List<Post> ViewAllPosts()
        {
            return bulletinboard.ViewAllPosts();
        }

        public List<Post> ViewWarningPosts()
        {
            return bulletinboard.GetPosts(PostType.Warning);
        }
        public List<Post> ViewRequestPosts()
        {
            return bulletinboard.GetPosts(PostType.Request);
        }
        public List<Post> ViewOfferPosts()
        {
            return bulletinboard.GetPosts(PostType.Offer);
        }

        public List<Post> ViewOfferPosts(string Supplier)
        {
            return bulletinboard.GetPosts(PostType.Offer, Supplier);
        }

        public void CreatePost(string owner, string title, string description, PostType type)
        {
            api.CreatePost(owner, title, description, type);
        }

        public void DeletePost(Post post)
        {
            api.DeletePost(post);
            bulletinboard.DeletePost(post);
        }

        public void EditPost(Post post, string newDescription, string newTitle)
        {
            api.EditPost(post, newDescription, newTitle);
        }


        public void ManageSupplerPage(Page page)
        {
            api.UpdatePage(page.Owner, page.Description, page.Location, page.ContactInformation);
        }

        public void AddNoteToSupplier(string supplierName, string editor, string text)
        {
            api.AddNoteToSupplier(supplierName, editor, text);
        }

        public List<Page> Search(string searchTerm)
        {
            return pageManager.Search(searchTerm);
        }

        public void EditProduct(Product product, string newProductName, string newChemicalName, Double newMolWeight,
            string newDescription, Double newPrice, string newPackaging, string newDeliveryTime)
        {

            if ((GetLoggedInUser().Username.Equals(product.Producer)) || (GetLoggedInUser().Rights==User.RightsEnum.Admin))
            {
                api.EditProduct(product, newProductName, newChemicalName, newMolWeight, newDescription, newPrice, newPackaging, newDeliveryTime);
            }
            else
            {
                //Some error since user not allowed to use this function
            }


        }
        

        public void CreateProduct(string productName, string chemicalName, Double molWeight, string description, Double price, string packaging, string deliveryTime, string producer)
        {
            pageManager.pages.Find(page => page.Owner.Equals(producer)).Products.Add(api.CreateProduct(productName, chemicalName, molWeight, description, price, packaging, deliveryTime, producer));
        }

        public void DeleteProduct(Product product)
        {
            if (GetLoggedInUser().Username.Equals(product.Producer) || GetLoggedInUser().Rights == User.RightsEnum.Admin)
            {
                api.DeleteProduct(product);
                pageManager.pages.Find(page => page.Owner.Equals(product.Producer)).Products.Remove(product);
            }
        }


        public void GetPDF(int? id)
        {
            new Thread(() =>
            {
                string finalString = new String(GetRandomCharArray(10)) + ".pdf";
                string filePath = Path.GetTempPath() + "Provider/";
                FileInfo FileInfo = new FileInfo(filePath);
                FileInfo.Directory.Create();
                var file = File.Create(filePath + finalString);

                api.GetPDF(id).CopyTo(file);

                file.Close();
                System.Diagnostics.Process.Start(filePath + finalString);
            }).Start();
        }

        public void DeleteTempFiles()
        {
            try
            {
                Directory.Delete(Path.GetTempPath() + "Provider", true);
            }
            catch (DirectoryNotFoundException e)
            {
                Environment.Exit(0);
            }
        }

        private char[] GetRandomCharArray(int size)
        {
            char[] chars = new char[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                chars[i] = (char) (random.Next(26) + 97);
            }
            return chars;
        }
    }
}
