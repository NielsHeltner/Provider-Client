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
        public enum Types { Warning, Request, Offer };
        public String owner { get; private set; }
        public DateTime creationDate { get; private set; }
        public string description { get; set; }
        public Types type { get; private set; }
        public string title { get; set; }

        public Post(String owner, string title, string description, Types type)
        {
            this.description = description;
            this.owner = owner;
            this.type = type;
            this.title = title;
            creationDate = DateTime.Now;
        }
    }
}
