using System;
using System.Collections.Generic;
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
    }
}
