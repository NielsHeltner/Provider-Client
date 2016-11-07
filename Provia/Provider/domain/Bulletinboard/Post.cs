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
        public AbstractUser owner { get; private set; }
        public DateTime creationDate { get; private set; }
        public string description { get; set; }
        public int type { get; private set; }
        public string title { get; set; }



        public Post(AbstractUser owner, string title, string description, int type)
        {
            this.description = description;
            this.owner = owner;
            this.type = type;
            this.title = title;
            creationDate = DateTime.Now;
        }
    }
}
