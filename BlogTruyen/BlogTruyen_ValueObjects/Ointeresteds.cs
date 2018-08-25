using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ointeresteds
    {
        public Guid Idinterested { get; set; }
        [Display(Name = "Cảm xúc")]
        public bool? Like { get; set; }
        [Display(Name = "Cảm xúc")]
        public bool? Love { get; set; }
        [Display(Name = "Cảm xúc")]
        public bool? Hate { get; set; }
        [Display(Name = "Tên truyện")]
        public Guid IdPost { get; set; }
        [Display(Name = "Tên người")]
        public Guid IdUser { get; set; }
    }
}
