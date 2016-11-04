using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.bulletinboard
{
    public class Post
    {
        private AbstractUser owner;
        private DateTime creationDate;
        public string description { get; set; }
        public int type { get; private set; }



        public Post(AbstractUser owner, string description, int type)
        {
            this.description = description;
            this.owner = owner;
            this.type = type;
            creationDate = DateTime.Now;
        }
    }
}
