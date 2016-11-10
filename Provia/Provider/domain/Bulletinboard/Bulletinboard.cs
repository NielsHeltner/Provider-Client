using System.Collections.Generic;
using Provider.db;

namespace Provider.domain.bulletinboard
{
    public class Bulletinboard
    {
        public List<Post> posts { get; }

        public Bulletinboard()
        {
            posts = Database.instance.GetPosts();
        }
        /// <summary>
        /// create a post
        /// </summary>
        /// <param name="owner">the owner of the post</param>
        /// <param name="description"> text in the post</param>
        /// <param name="type">takes a integer
        /// "1" is warningPost
        /// "2" is requestPost
        /// "3" is offerPost
        /// </param>
        public void CreatePost(string owner, string title, string description, Post.Types type)
        {
            Post post = new Post(owner, title, description, type);
            post.id = Database.instance.AddPost(owner, post);
            posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            Database.instance.DeletePost(post);
            posts.Remove(post);
        }

        public void EditPost(Post post, string newDescription, string newTitle)
        {
            Post postFound = posts.Find(p => p == post);
            postFound.description = newDescription;
            postFound.title = newTitle;
            Database.instance.UpdatePost(post.owner, post);
        }

        private List<Post> GetPosts(Post.Types type)
        {
            List<Post> postResults = new List<Post>();
            foreach (Post post in posts)
            {
                if (post.type == type)
                {
                    postResults.Add(post);
                }
            }
            return postResults;
        }
        public List<Post> ViewAllPosts()
        {
            return posts;
        }

        public List<Post> ViewWarningPosts()
        {
            return GetPosts(Post.Types.Warning);
        }
        public List<Post> ViewRequestPosts()
        {
            return GetPosts(Post.Types.Request);
        }
        public List<Post> ViewOfferPosts()
        {
            return GetPosts(Post.Types.Offer);
        }
    }
}