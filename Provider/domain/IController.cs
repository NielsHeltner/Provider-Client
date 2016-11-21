using System;
using System.Collections.Generic;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;
using IO.Swagger.Model;

namespace Provider.domain
{
    public interface IController
    {
        List<IO.Swagger.Model.Page> GetPages();

        void EditPost(Post post, string newDescription, string newTitle);

        void DeletePost(Post post);

        void CreatePost(String owner, string title, string description, Post.TypesEnum type);

        bool LogIn(string userName, string password);

        void LogOut();

        IO.Swagger.Model.User GetLoggedInUser();

        /// Retuns a list of posts.
        /// If type = "0" all posts are returned
        /// If type = "1" warningPost are returned
        /// If type = "2" requestPost are returned
        /// If type = "3" offerPost are returned
        List<Post> ViewAllPosts();

        List<Post> ViewWarningPosts();

        List<Post> ViewRequestPosts();

        List<Post> ViewOfferPosts();

        void AddNoteToSupplier(string supplierName, string editor, string text);

        List<Page> Search(string searchTerm);
    }
}
    