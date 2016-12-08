using System;
using System.Collections.Generic;
using System.IO;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;
using IO.Swagger.Model;

namespace Provider.domain
{
    public interface IController
    {
        Object GetUpdateLock();
        List<Page> GetPages();

        void EditPost(Post post, string newDescription, string newTitle);

        void DeletePost(Post post);

        void CreatePost(string owner, string title, string description, PostType type);

        void DeleteProduct(Product product);

        void EditProduct(Product product, string newProductName, string newChemicalName, Double newMolWeight,
            string newDescription, Double newPrice, string newPackaging, string newDeliveryTime);

        void CreateProduct(string ProductName, string ChemicalName, Double MolWeight, string Description, Double Price,
            string Packaging, string DeliveryTime, string Producer);

        bool LogIn(string userName, string password);

        void LogOut();

        User GetLoggedInUser();

        List<Post> ViewAllPosts();

        List<Post> ViewWarningPosts();

        List<Post> ViewRequestPosts();

        List<Post> ViewOfferPosts();

        List<Post> ViewOfferPosts(string Supplier);

        void AddNoteToSupplier(string supplierName, string editor, string text);

        List<Page> Search(string searchTerm);

        void GetPDF(int? id);

        void DeleteTempFiles();
        void ManageSupplierPage(Page page);
    }
}
    