using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ocategories
    {
        [Display(Name ="Mã nhóm")]
        public int IdCategory { get; set; }
        [Display(Name = "Tên nhóm")]
        public string CategoryName { get; set; }
    }
}
