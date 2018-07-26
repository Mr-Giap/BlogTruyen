using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ointeresteds
    {
        public Guid Idinterested { get; set; }
        public bool? Like { get; set; }
        public bool? Love { get; set; }
        public bool? Hate { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUser { get; set; }
    }
}
