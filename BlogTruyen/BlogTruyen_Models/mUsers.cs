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
        public override int Gettotal()
        {
            int total = int.Parse(db.User_CountAll().ToString());
            return total;
        }
        public override int CheckActive(Guid id)
        {
            int rs = 0;
            rs = int.Parse(db.User_CheckActive(id).ToString());
            return rs;
        }
        public override int CheckUsername(string username)
        {
            int rs = int.Parse(db.User_CheckUsername(username).ToString());
            return rs;
        }
        public override Ousers GetbyId(Guid id)
        {
            Ousers user = new Ousers();
            var item = db.User_GetbyId(id).FirstOrDefault();
            if(item == null)
            {
                return user;
            }
            else
            {
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
                user.Role = new Oroles { RoleId = item.RoleId};

                return user;
            }
        }
        public override int Add(Ousers user)
        {
            db.User_Insert(user.IdUser,user.FullName,user.Avatar,user.Address,user.Email,user.PhoneNumber,user.Sex,user.BirthDay,user.UserName,user.PassWord,user.DateCreate,user.AboutMe,user.Permission,user.PassActive,user.IsActived,user.IsDelete,user.Role.RoleId);
            return 1;
        }
        public override int Update(Ousers user)
        {
            db.User_Update(user.IdUser, user.FullName, user.Avatar, user.Address, user.Email, user.PhoneNumber, user.Sex, user.BirthDay, user.UserName, user.PassWord, user.AboutMe, user.Permission, user.PassActive, user.IsActived, user.IsDelete, user.Role.RoleId);
            return 1;
        }
        public override int Delete(Guid id)
        {
            db.User_Delete(id);
            return 1;
        }
    }
}
