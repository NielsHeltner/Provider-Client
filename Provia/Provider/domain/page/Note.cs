using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class Note
    {
        public string text { get; set; }
        public DateTime creationDate { get; private set; }

        public Note(string text, DateTime creationDate)
        {
            this.text = text;
            this.creationDate = creationDate;
        }
        public Note(string text) : this(text, DateTime.Today) { }
        
    }
}
