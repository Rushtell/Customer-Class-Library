using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public class Note
    {
        public int NoteId { get; set; }

        public int CustomerId { get; set; }

        public string Text { get; set; }
    }
}
