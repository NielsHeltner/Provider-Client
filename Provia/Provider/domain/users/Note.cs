using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.users
{
    public class Note
    {
        public string note { get; set; }
        public DateTime creationDate { get; private set; }

        public Note(string note)
        {
            this.note = note;
            creationDate = DateTime.Now;
        }
    }
}
