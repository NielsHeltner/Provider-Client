using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Provider.domain.bulletinboard
{
    public interface IBulletinboard
    {

        List<Post> posts { get; set; }

        List<Post> GetPosts(PostType type);

        void GetPosts();

        void CreatePost(string owner, string title, string description, PostType type);

        void DeletePost(Post post);

        void EditPost(Post post, string newDescription, string newTitle);

    }
}