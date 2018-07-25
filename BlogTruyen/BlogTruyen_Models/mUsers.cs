using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mUsers:BaseUser<Ousers>
    {
        public override int Checklogin(string username, string password)
        {
            int rs = 0;
            var kq = db.User_CheckLogin(username, password);
            if(kq.Count() == 0)
            {
                rs = 0;
            }
            else
            {
                rs = 1;
            }
            return rs;
        }
        public override List<Ousers> Getall(int start, int length)
        {
            List<Ousers> list = new List<Ousers>();
            var data = db.User_getallpaging(start, length);
            foreach(var item in data)
            {
                Ousers user = new Ousers();
                user.IdUser = item.IdUser;
                user.FullName = item.FullName;
                user.Avatar = item.Avatar;
                user.Address = item.Address;
                user.Email = item.Email;
                user.PhoneNumber = item.PhoneNumber;
                user.Sex = item.Sex;
                user.BirthDay = item.BirthDay;
                user.UserName = item.UserName;
                user.PassWord = item.PassWord;
                user.DateCreate = item.DateCreate;
                user.AboutMe = item.AboutMe;
                user.Permission = item.Permission;
                user.PassActive = item.PassActive;
                user.IsActived = item.IsActived;
                user.IsDelete = item.IsDelete;
                user.Role = new Oroles { RoleId = item.RoleId, RoleName = item.RoleName };
            }
            return list ;
        }
    }
}
