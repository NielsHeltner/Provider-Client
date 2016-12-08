using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;

namespace Provider.domain.bulletinboard
{
    public interface IBulletinboard
    {

        List<Post> posts { get; set; }

        List<Post> GetPosts(PostType type);

        List<Post> GetPosts(PostType type, string Supplier);

    }
}