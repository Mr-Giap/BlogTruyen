using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Oroles
    {
        [Display(Name ="Mã quyền")]
        public int RoleId { get; set; }
        [Display(Name ="Tên quyền")]
        public string RoleName { get; set; }
    }
}
