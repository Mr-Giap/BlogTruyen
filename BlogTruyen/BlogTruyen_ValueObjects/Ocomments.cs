using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ocomments
    {
        public Guid IdComment { get; set; }

        public Guid IdPost { get; set; }
        [Display(Name = "Người bình luận")]
        public Guid IdUser { get; set; }
        [Display(Name = "Trả lời ai")]
        public Guid? ReplyToUser { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreate { get; set; }
    }
}
