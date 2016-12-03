using System.Collections.Generic;
using IO.Swagger.Model;

namespace Provider.domain.bulletinboard
{
    public class Bulletinboard
    {
        public List<Post> posts { get; set; }

        public Bulletinboard()
        {
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
        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            posts.Remove(post);
        }

        public List<Post> GetPosts(PostType type)
        {
            List<Post> postResults = new List<Post>();
            foreach (Post post in posts)
            {
                if (post.Type == type)
                {
                    postResults.Add(post);
                }
            }
            return postResults;
        }

        public List<Post> GetPosts(PostType type, string Supplier)
        {
            List<Post> PostResults = new List<Post>();
            foreach (Post post in posts)
            {
                if(post.Type == type && post.Owner.Equals(Supplier))
                {
                    PostResults.Add(post);
                }
            }
            return PostResults;
        }

        public List<Post> ViewAllPosts()
        {
            return posts;
        }
    }
}