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
        /// Adds a post to a list of posts.
        /// </summary>
        /// <param name="post">The post which is being added</param>
        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        /// <summary>
        /// Deletes a post 
        /// </summary>
        /// <param name="post">The post which is being deleted </param>
       public void DeletePost(Post post)
        {
            posts.Remove(post);
        }

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
        /// Lists all the posts. 
        /// </summary>
        /// <returns> A list of all posts</returns>
        public List<Post> ViewAllPosts()
        {
            return posts;
        }
    }
}