using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ochapters
    {
        public Guid IdChapter { get; set; }
        [Display(Name ="Tên truyện")]
        public Guid IdPost { get; set; }
        [Display(Name = "Tên chương")]
        public int NameChap { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string ChapContent { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreate { get; set; }
        [Display(Name = "Đã xóa")]
        public bool IsDelete { get; set; }
    }
}
