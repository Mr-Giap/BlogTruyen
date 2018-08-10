using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Oposts
    {
        public Guid IdPost { get; set; }
        [Display(Name = "Tên truyện")]
        [StringLength(5, ErrorMessage = "Vui lòng nhập tên của truyện")]
        public string PostName { get; set; }
        public string NameAscii { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Introduction { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string Avatar { get; set; }
        [Display(Name = "Độ dài của truyện")]
        public int? Length { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreate { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Người tạo")]
        public Guid IdUser { get; set; }
        [Display(Name = "Nguồn")]
        public string Source { get; set; }
        [Display(Name = "Tác giả")]
        public string Author { get; set; }
        [Display(Name = "Đã xóa")]
        public bool IsDelete { get; set; }
        [Display(Name = "Đã hoàn thành")]
        public bool IsFull { get; set; }
        [Display(Name = "Nhóm")]
        public int IdCategory { get; set; }
        [Display(Name = "Thể loại")]
        public string Type { get; set; }
        [Display(Name = "Hậu truyện")]
        public string Child { get; set; }
    }
}
