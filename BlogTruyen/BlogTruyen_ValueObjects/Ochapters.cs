using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ochapters
    {
        public int IdChapter { get; set; }
        public Guid IdPost { get; set; }
        public string Title { get; set; }
        public string ChapContent { get; set; }
        public string Note { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
