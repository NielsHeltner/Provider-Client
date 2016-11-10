using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.db;
using Provider.domain.bulletinboard;

namespace Provider.domain.bulletinboard
{
    public class Bulletinboard
    {
        public List<Post> posts { get; private set; }

        public Bulletinboard()
        {
            posts = Database.instance.GetPosts();
            /*posts.Add(new Post("Vitafit", "sejhed", "vi er seje", Post.Types.Warning));
            posts.Add(new Post("B2Vitas", "mere sejhed","vi er også seje", Post.Types.Request));
            posts.Add(new Post("ProteinVitmins", "mest sejhed","vi er ok seje", Post.Types.Offer));*/
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

        // Retuns a list of posts.
        // If type = "0" all posts are returned
        // If type = "1" warningPost are returned
        // If type = "2" requestPost are returned
        // If type = "3" offerPost are returned
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