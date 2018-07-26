using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cUsers:BaseUser<Ousers>
    {
        public override int Checklogin(string username, string password)
        {
            return model.Checklogin(username, password);
        }
        public override int CheckActive(Guid id)
        {
            return model.CheckActive(id);
        }
        public override int CheckUsername(string username)
        {
            return model.CheckUsername(username);
        }
        public override List<Ousers> Getall(int start, int length)
        {
            return model.Getall(start,length);
        }
        public override Ousers GetbyId(Guid id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Ousers user)
        {
            return model.Add(user);
        }
        public override int Update(Ousers user)
        {
            return model.Update(user);
        }
        public override int Delete(Guid id)
        {
            return model.Delete(id);
        }
    }
}
