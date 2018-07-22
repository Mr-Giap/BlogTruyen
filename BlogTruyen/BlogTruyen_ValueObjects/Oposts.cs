using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Oposts
    {
        public Guid IdPost { get; set; }
        public string PostName { get; set; }
        public string NameAscii { get; set; }
        public string Introduction { get; set; }
        public string Avatar { get; set; }
        public int? Length { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Note { get; set; }
        public Guid IdUser { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public bool IsDelete { get; set; }
        public bool IsFull { get; set; }
        public int IdCategory { get; set; }
        public string Type { get; set; }
        public string Child { get; set; }
    }
}
