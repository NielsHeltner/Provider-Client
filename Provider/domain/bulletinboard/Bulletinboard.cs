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