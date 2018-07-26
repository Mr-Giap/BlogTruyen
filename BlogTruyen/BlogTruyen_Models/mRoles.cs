using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;
namespace BlogTruyen_Models
{
    public class mRoles:BaseRoles<Oroles>
    {
        public override List<Oroles> GetAllpaging(int start, int length)
        {
            List<Oroles> list = new List<Oroles>();
            var data = db.Roles_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Oroles role = new Oroles();
                    role.RoleId = item.RoleId;
                    role.RoleName = item.RoleName;

                    list.Add(role);
                }
                return list;
            }
            return list;
        }
        public override Oroles GetbyId(int id)
        {
            Oroles role = new Oroles();
            var item = db.Roles_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                role.RoleId = item.RoleId;
                role.RoleName = item.RoleName;
                return role;
            }
            return role;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Roles_CountAll().ToString());
            return rs;

        }
        public override int Add(Oroles Role)
        {
            db.Roles_Insert(Role.RoleName);
            return 1;
        }
        public override int Update(Oroles role)
        {
            db.Roles_Update(role.RoleId, role.RoleName);
            return 1;
        }
        public override int Delete(int id)
        {
            db.Roles_Delete(id);
            return 1;
        }
    }
}
