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
            posts.Add(new Post(new Supplier("Vitafit", "password1234"), "vi er seje", 2));
            posts.Add(new Post(new Supplier("B2Vitas", "password1234"), "vi er også seje", 2));
            posts.Add(new Post(new Supplier("ProteinVitmins", "password1234"), "vi er ok seje", 2));
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

        public void DeletePost(Post post)
        {
            posts.Remove(post);
        }

        public void EditPost(string editedText, Post post)
        {
            posts.Find(x => x == post).description = editedText;
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