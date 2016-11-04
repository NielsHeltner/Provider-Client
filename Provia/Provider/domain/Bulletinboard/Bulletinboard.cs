using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.Bulletinboard
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
        internal List<Post> ViewBulletinBoard(int type)
        {
            if (type.Equals(1))
            {
                List<Post> warningPost = new List<Post>();
                foreach (Post postinList in posts)
                {
                    if(postinList.type == 1)
                    warningPost.Add(postinList);
                }
                return warningPost;
            }
            else if (type.Equals(2))
            {
                List<Post> requestPost = new List<Post>();
                foreach (Post postinList in posts)
                {
                    if (postinList.type == 2)
                        requestPost.Add(postinList);
                }
                return requestPost;
            }
            else if (type.Equals(3))
            {
                List<Post> offerPost = new List<Post>();
                foreach (Post postinList in posts)
                {
                    if (postinList.type == 3)
                        offerPost.Add(postinList);
                }
                return offerPost;
            }
            else
            {
                return posts;
                {

                }
            }
        }
    }
}