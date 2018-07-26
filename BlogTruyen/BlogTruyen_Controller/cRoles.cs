using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_ValueObjects;
using BlogTruyen_Controller.BaseController;

namespace BlogTruyen_Controller
{
    public class cRoles:BaseRole<Oroles>
    {
        public override List<Oroles> GetAllpaging(int start, int length)
        {
            return model.GetAllpaging(start,length);
        }
        public override Oroles GetbyId(int id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Oroles Role)
        {
            return model.Add(Role);
        }
        public override int Update(Oroles role)
        {
            return model.Update(role);
        }
        public override int Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
