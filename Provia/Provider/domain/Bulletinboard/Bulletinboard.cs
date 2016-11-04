using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.Bulletinboard
{
    public class Bulletinboard
    {
        public void CreatePost(AbstractUser owner, string description) {
            new Post(owner, description);
        }

    }
}
