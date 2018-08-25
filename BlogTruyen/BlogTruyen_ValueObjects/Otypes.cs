using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Otypes
    {
        [Display(Name ="Mã loại")]
        public int IdType { get; set; }
        [Display(Name = "Tên loại")]
        public string TypeName { get; set; }
    }
}
