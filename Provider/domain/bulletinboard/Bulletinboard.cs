using System.Collections.Generic;
using IO.Swagger.Model;
using System.Linq;
using IO.Swagger.Api;

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
        /// This method lists all the posts on the bulletinboard. 
        /// </summary>
        /// <returns> A list of all posts</returns>
        public void GetPosts(ControllerApi api)
        {
            posts = api.GetAllPosts();
        }

        /// <summary>
        /// This method creates a post with a title, description and a post type. 
        /// </summary>
        /// <param name="owner">The owner of the post</param>
        /// <param name="title"> The title of the post</param>
        /// <param name="description"> The description of the post</param>
        /// <param name="type">The type of the post</param>
        public void CreatePost(string owner, string title, string description, PostType type, ControllerApi api)
        {
            api.CreatePost(owner, title, description, type);
        }

        /// <summary>
        /// Deletes a post and removes it from the bulletinboard.
        /// </summary>
        /// <param name="post">The post which is being deleted.</param>
        public void DeletePost(Post post, ControllerApi api)
        {
            api.DeletePost(post);
        }

        /// <summary>
        /// Edits an existing post. 
        /// </summary>
        /// <param name="post">The post which is being edited</param>
        /// <param name="newDescription"> The updated description of the post</param>
        /// <param name="newTitle"> The updated title of the post</param>
        public void EditPost(Post post, string newDescription, string newTitle, ControllerApi api)
        {
            api.EditPost(post, newDescription, newTitle);
        }

    }
}