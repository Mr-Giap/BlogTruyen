using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ochapters
    {
        public Guid IdChapter { get; set; }
        public Guid IdPost { get; set; }
        public int NameChap { get; set; }
        public string Title { get; set; }
        public string ChapContent { get; set; }
        public string Note { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool IsDelete { get; set; }
    }
}
