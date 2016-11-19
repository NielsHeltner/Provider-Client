using System;

namespace Provider.domain.bulletinboard
{
    public class Post
    {
        public enum Types
        {
            Warning,
            Request,
            Offer,
            NotAvailabe
        };

        public int id { get; set; }
        public String owner { get; private set; }
        public DateTime creationDate { get; private set; }
        public string description { get; set; }
        public Types type { get; private set; }
        public string title { get; set; }

        public Post(string owner, string title, string description, Types type, DateTime creationDate, int id)
        {
            this.description = description;
            this.owner = owner;
            this.type = type;
            this.title = title;
            this.creationDate = creationDate;
            this.id = id;
        }

        public Post(string owner, string title, string description, Types type) : 
            this(owner, title, description, type, DateTime.Now, default(int)) { }
    }
}
