using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ocomments
    {
        public Guid IdComment { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUser { get; set; }
        public Guid? ReplyToUser { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
