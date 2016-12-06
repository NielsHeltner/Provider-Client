using System.Collections.Generic;
using IO.Swagger.Model;
using System.Linq;

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
            return posts.AsParallel().Where(post => post.Type == type).ToList();
        }

        public List<Post> GetPosts(PostType type, string Supplier)
        {
            return GetPosts(type).AsParallel().Where(post => post.Owner.Equals(Supplier)).ToList();
        }

        public List<Post> ViewAllPosts()
        {
            return posts;
        }
    }
}