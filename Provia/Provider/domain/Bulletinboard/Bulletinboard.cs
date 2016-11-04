using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.bulletinboard
{
    public class Bulletinboard
    {
        public List<Post> posts { get; private set; }

        public Bulletinboard()
        {
            posts = new List<Post>();
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
        public void CreatePost(AbstractUser owner, string description, int type)
        {
            posts.Add(new Post(owner, description, type));
        }

        // Retuns a list of posts.
        // If type = "0" all posts are returned
        // If type = "1" warningPost are returned
        // If type = "2" requestPost are returned
        // If type = "3" offerPost are returned
        public List<Post> ViewBulletinBoard(int type)
        {
            if(type == 0)
            {
                return posts;
            }
            List<Post> postResults = new List<Post>();
            foreach (Post post in posts)
            {
                if(post.type == type)
                {
                    postResults.Add(post);
                }
            }
            return postResults;
        }
    }
}