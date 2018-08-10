using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ousers
    {
        public Guid IdUser { get; set; }
        [Display(Name = "Tên đầy đủ")]
        [StringLength(5, ErrorMessage = "Vui lòng nhập tên của bạn")]
        public string FullName { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Giới tính")]
        public bool? Sex { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreate { get; set; }
        [Display(Name = "Giới thiệu về bản thân")]
        public string AboutMe { get; set; }
        public byte? Permission { get; set; }
        public string PassActive { get; set; }
        [Display(Name = "Đã kích hoạt chưa")]
        public bool IsActived { get; set; }
        [Display(Name = "Đã xóa chưa")]
        public bool IsDelete { get; set; }
        [Display(Name = "Quyền")]
        public Oroles Role { get; set; }
    }
}
