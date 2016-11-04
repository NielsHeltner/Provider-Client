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