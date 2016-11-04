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

        public Note(string text)
        {
            this.text = text;
            creationDate = DateTime.Now;
        }
    }
}
