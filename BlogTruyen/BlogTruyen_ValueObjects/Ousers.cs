using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTruyen_ValueObjects
{
    public class Ousers
    {
        public Guid IdUser { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Sex { get; set; }
        public DateTime BirthDay { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? DateCreate { get; set; }
        public string AboutMe { get; set; }
        public byte? Permission { get; set; }
        public string PassActive { get; set; }
        public bool IsActived { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
    }
}
