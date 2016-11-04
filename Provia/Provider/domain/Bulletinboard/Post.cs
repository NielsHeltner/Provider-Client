using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.Bulletinboard
{
    public class Post
    {
        string description;
        DateTime creationDate;
        AbstractUser owner;
        
        public Post(AbstractUser owner, string description)
        {
            this.description = description;
            this.owner = owner;
        }

    }
}
