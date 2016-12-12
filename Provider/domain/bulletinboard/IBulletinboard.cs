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

        void GetPosts(ControllerApi api);

        void CreatePost(string owner, string title, string description, PostType type, ControllerApi api);

        void DeletePost(Post post, ControllerApi api);

        void EditPost(Post post, string newDescription, string newTitle, ControllerApi api);

    }
}