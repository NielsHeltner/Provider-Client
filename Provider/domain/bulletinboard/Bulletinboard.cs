using System.Collections.Generic;
using IO.Swagger.Model;
using System.Linq;

namespace Provider.domain.bulletinboard
{
    public class Bulletinboard : IBulletinboard
    {
        public List<Post> posts { get; set; }

        /// <summary>
        /// Gets all post with a given post type. 
        /// </summary>
        /// <param name="type">The type of the posts which is being returned</param>
        /// <returns> A list of posts with the given post type </returns>
        public List<Post> GetPosts(PostType type)
        {
            return posts.AsParallel().Where(post => post.Type == type).ToList();
        }

        /// <summary>
        /// Gets all post with a given post type and name of supplier. 
        /// </summary>
        /// <param name="type">The type of the posts</param>
        /// <param name="Supplier">The name of the supplier</param>
        /// <returns> A list of posts with the given post type and name of the supplier</returns>
        public List<Post> GetPosts(PostType type, string Supplier)
        {
            return GetPosts(type).AsParallel().Where(post => post.Owner.Equals(Supplier)).ToList();
        }

    }
}